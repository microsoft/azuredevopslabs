// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using LaunchDarkly.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PartsUnlimited.Models;
using PartsUnlimited.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartsUnlimited.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPartsUnlimitedContext _db;
        private readonly IMemoryCache _cache;
        public int roco_count = 1000;
        static LdClient client = new LdClient("__YourLaunchDarklySDKKey__"); //LaunchDarkly API key


        public HomeController(IPartsUnlimitedContext context, IMemoryCache memoryCache)
        {
            _db = context;
            _cache = memoryCache;
        }

        //
        // GET: /Home/
        public IActionResult Index()
        {
            // Get most popular products
            List<Product> topSellingProducts;
            if (!_cache.TryGetValue("topselling", out topSellingProducts))
            {
                topSellingProducts = GetTopSellingProducts(4);
                //Refresh it every 10 minutes. Let this be the last item to be removed by cache if cache GC kicks in.
                _cache.Set("topselling", topSellingProducts, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)).SetPriority(CacheItemPriority.High));
            }
            
            List<Product> newProducts;
            if (!_cache.TryGetValue("newarrivals", out newProducts))
            {
                newProducts = GetNewProducts(4);
                //Refresh it every 10 minutes. Let this be the last item to be removed by cache if cache GC kicks in.
                _cache.Set("newarrivals", newProducts, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)).SetPriority(CacheItemPriority.High));
            }

            var viewModel = new HomeViewModel
            {
                NewProducts = newProducts,
                TopSellingProducts = topSellingProducts,
                CommunityPosts = GetCommunityPosts()
            };
            var category = _db.Categories.ToList();
            //LaunchDarkly start
            User user = LaunchDarkly.Client.User.WithKey("administrator@test.com");
            bool value = client.BoolVariation("member-portal", user, false);
            if (value)
            {
                ViewBag.Message = "Your application description page.";
                ViewData["togglevalue"] = value;
                return View(viewModel);
            }
            else
            {
                return View(viewModel);
            }
           // return View(viewModel);

        }
        //LaunchDarkly End
        //Can be removed and handled when HandleError filter is implemented
        //https://github.com/aspnet/Mvc/issues/623
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        private List<Product> GetTopSellingProducts(int count)
        {
            // Group the order details by product and return
            // the products with the highest count

            // TODO [EF] We don't query related data as yet, so the OrderByDescending isn't doing anything
            return _db.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        private List<Product> GetNewProducts(int count)
        {
            return _db.Products
                .OrderByDescending(a => a.Created)
                .Take(count)
                .ToList();
        }

        private List<CommunityPost> GetCommunityPosts()
        {
            return new List<CommunityPost>{
                new CommunityPost {
                    Content= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus commodo tellus lorem, et bibendum velit sagittis in. Integer nisl augue, cursus id tellus in, sodales porta.",
                    DatePosted = DateTime.Now,
                    Image = "community_1.png",
                    Source = CommunitySource.Facebook
                },
                new CommunityPost {
                    Content= " Donec tincidunt risus in ligula varius, feugiat placerat nisi condimentum. Quisque rutrum eleifend venenatis. Phasellus a hendrerit urna. Cras arcu leo, hendrerit vel mollis nec.",
                    DatePosted = DateTime.Now,
                    Image = "community_2.png",
                    Source = CommunitySource.Facebook
                },
                new CommunityPost {
                    Content= "Aenean vestibulum non lacus non molestie. Curabitur maximus interdum magna, ullamcorper facilisis tellus fermentum eu. Pellentesque iaculis enim ac vestibulum mollis.",
                    DatePosted = DateTime.Now,
                    Image = "community_3.png",
                    Source = CommunitySource.Facebook
                },
                new CommunityPost {
                    Content= "Ut consectetur sed justo vel convallis. Vestibulum quis metus leo. Nulla hendrerit pharetra dui, vel euismod lectus elementum sit amet. Nam dolor turpis, sodales non mi nec.",
                    DatePosted = DateTime.Now,
                    Image = "community_4.png",
                    Source = CommunitySource.Facebook
                }
            };
        }


        //stubbing in a recommendations action
        public ActionResult Recommendations()
        {
            int count = 0;
            while ( count < roco_count
                   )
            {
                _db.Products
                    .OrderByDescending(a => a.OrderDetails.Count())
                    .Take(count++)
                    .ToList();
            }

            return View();
        }
    }
}
