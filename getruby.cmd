@if "%SCM_TRACE_LEVEL%" NEQ "4" @echo off

REM Put Ruby in Path
REM You can also use %TEMP% but it is cleared on site restart. Tools is persistent.
SET PATH=%PATH%;D:\home\site\deployments\tools\r\ruby-2.3.1-x64-mingw32\bin

REM I am in the repository folder
pushd D:\home\site\deployments
if not exist tools md tools
cd tools 
if not exist r md r
cd r 
if exist ruby-2.3.1-x64-mingw32 goto end

echo No Ruby, need to get it!

REM Get Ruby and Rails
REM 64bit
curl -o ruby231.zip -L https://bintray.com/artifact/download/oneclick/rubyinstaller/ruby-2.3.1-x64-mingw32.7z?direct
REM Azure puts 7zip here!
echo START Unzipping Ruby
SetLocal DisableDelayedExpansion & d:\7zip\7za x -xr!*.ri -y ruby231.zip > rubyout
echo DONE Unzipping Ruby

REM Get DevKit to build Ruby native gems  
REM If you don't need DevKit, rem this out.
curl -o DevKit.zip http://cdn.rubyinstaller.org/archives/devkits/DevKit-mingw64-64-4.7.2-20130224-1432-sfx.exe
echo START Unzipping DevKit
d:\7zip\7za x -y -oDevKit DevKit.zip > devkitout
echo DONE Unzipping DevKit

REM Init DevKit
ruby DevKit\dk.rb init

REM Tell DevKit where Ruby is
echo --- > config.yml
echo - D:/home/site/deployments/tools/r/ruby-2.3.1-x64-mingw32 >> config.yml

REM Setup DevKit
ruby DevKit\dk.rb install

REM Update until someone fixes the Ruby Windows installer https://github.com/oneclick/rubyinstaller/issues/261
curl -L -o update.gem https://rubygems.org/gems/rubygems-update-2.6.8.gem
call gem install --local update.gem
call update_rubygems --no-ri --no-rdoc > updaterubygemsout
ECHO What's our new Rubygems version?
call gem --version
call gem uninstall rubygems-update -x

popd

:end

REM Need to be in Reposistory
cd %DEPLOYMENT_SOURCE%
cd

call gem install bundler --no-ri --no-rdoc

ECHO Bundler install (not update!)
call bundle install

cd %DEPLOYMENT_SOURCE%
cd

ECHO Running Jekyll
call bundle exec jekyll build

REM KuduSync is after this!
