#!/bin/bash


################################################################
# Section 0 - Validate Input and Get Parameters
################################################################

### Validate parameters
if [[ !("$#" -eq 3) ]]; 
    then echo "Parameters missing for java vm configuration." >&2
    exit 1
fi

### Get parameters
username=$1
azureregion=$2
branch=$3

################################################################
# Section 1 - Install Apps and Files
################################################################
apt-get update


### Set environment variable for Java
echo "export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64" >> /home/$username/.profile
echo "export MAVEN_HOME=/usr/share/maven" >> /home/$username/.profile

### Install UMake
add-apt-repository ppa:ubuntu-desktop/ubuntu-make -y
apt-get update
apt-get install ubuntu-make -y

### Install Eclipse
sudo -u $username umake ide eclipse-jee /home/$username/.local/share/umake/ide/eclipse



################################################################
# Section 2 - Configure Desktop Environment and Remote Connectivity
################################################################

### Install and configure xfce and xrdp
apt-get update
apt-get install xfce4 -y
apt-get install xrdp -y
apt-get install gnome-terminal -y

cd /mnt
git clone https://github.com/bayernmunich/Eclipse.git

cd /mnt/java-dev-vsts
git checkout $branch

cp -r /mnt/java-dev-vsts/env/config-template/* /home/$username/.config
find /home/$username/.config -type f -exec sed -i "s/__USERNAME__/$username/g" {} +
chown -R $username /home/$username/.config/*


### Compile new version of xrdp
### Modified version of install-xrdp-1.8.sh from http://www.c-nergy.be/blog
################################################################
# Script_Name : install-xrdp-1.8.sh
# Description : Perform an automated custom installation of xrdp
# on ubuntu 16.04.2
# Date : April 2017
# written by : Griffon
# Web Site :http://www.c-nergy.be - http://www.c-nergy.be/blog
# Version : 1.8
#
# Disclaimer : Script provided AS IS. Use it at your own risk....
#
##################################################################

#Step 1 - Install prereqs for compilation
##################################################################
 
echo "Installing prereqs for compiling xrdp..."
echo "----------------------------------------"
apt-get -y install libx11-dev libxfixes-dev libssl-dev libpam0g-dev libtool libjpeg-dev flex bison gettext autoconf libxml-parser-perl libfuse-dev xsltproc libxrandr-dev python-libxml2 nasm xserver-xorg-dev fuse git pkg-config


#********
#Temporary fix for xrdp compilation issue due to Ubuntu package missing fontutil.h
#********
#https://github.com/neutrinolabs/xorgxrdp/issues/100
#https://bugs.launchpad.net/ubuntu/+source/libxfont/+bug/1707691
##################################################################
if test -s "/usr/include/X11/fonts/fontutil.h"
then
    echo "fontutil.h already exists...issue is fixed and workaround is no longer necessary"
else
    echo "fontutil.h missing...copying from repo"
    cp /mnt/java-dev-vsts/env/tempXrdpFix/fontutil.h /usr/include/X11/fonts/fontutil.h
fi
#********
#End temporary fix for xrdp compilation issue due to Ubuntu package missing fontutil.h
#********


#Step 2 - Obtain xrdp packages 
################################################################## 

## --Go to your Download folder
echo "Moving to the ~/Download folders..."
echo "-----------------------------------"
cd /mnt


## -- Download the xrdp latest files
echo "Ready to start the download of xrdp package"
echo "-------------------------------------------"
git clone https://github.com/neutrinolabs/xrdp.git

## -- compiling xrdp packages

echo "Installing and compiling xrdp..."
echo "--------------------------------"
cd /mnt/xrdp
./bootstrap
./configure --enable-fuse --enable-jpeg  
make
make install

#Step 3 -  Download and compiling xorgxrdp packages
################################################################## 
cd /mnt
git clone https://github.com/neutrinolabs/xorgxrdp.git


cd /mnt/xorgxrdp 
./bootstrap 
./configure 
make
make install

#Step 4 - Modify Service Unit Files
################################################################## 

## Needed in order to have systemd working properly with xrdp
echo "-----------------------"
echo "Modify xrdp.service "
echo "-----------------------"
#Comment the EnvironmentFile - Ubuntu does not have sysconfig folder
sed -i.bak 's/EnvironmentFile/#EnvironmentFile/g' /lib/systemd/system/xrdp.service

echo "-----------------------"
echo "Modify xrdp-sesman.service "
echo "-----------------------"
#Comment the EnvironmentFile - Ubuntu does not have sysconfig folder
sed -i.bak 's/EnvironmentFile/#EnvironmentFile/g' /lib/systemd/system/xrdp-sesman.service

#Issue systemctl command to reflect change and enable the service
systemctl daemon-reload
systemctl enable xrdp.service

## copy the following in the .xsession file 
echo xfce4-session >/home/$username/.xsession

## Configure Polkit to avoid popu in Xrdp Session
cat >/etc/polkit-1/localauthority.conf.d/02-allow-colord.conf  <<EOF

polkit.addRule(function(action, subject) {
if ((action.id == “org.freedesktop.color-manager.create-device” ||
action.id == “org.freedesktop.color-manager.create-profile” ||
action.id == “org.freedesktop.color-manager.delete-device” ||
action.id == “org.freedesktop.color-manager.delete-profile” ||
action.id == “org.freedesktop.color-manager.modify-device” ||
action.id == “org.freedesktop.color-manager.modify-profile”) &&
subject.isInGroup(“{group}”)) {
return polkit.Result.YES;
}
});
EOF

### Upgrade packages
apt-get upgrade -y

### Reboot
echo "Restart the Computer"
echo "----------------------------"
shutdown -r 1

exit 0
