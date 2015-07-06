﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TMD.Interfaces.IServices;
using TMD.Models.RequestModels;
using TMD.Web.ModelMappers;
using TMD.Web.Models;
using TMD.Web.ViewModels;
using TMD.Web.ViewModels.Common;

namespace TMD.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        // GET: ProductCategory
        public ActionResult Index()
        {
            ProductCategorySearchRequest searchRequest = Session["PageMetaData"] as ProductCategorySearchRequest;
            Session["PageMetaData"] = null;
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            return View(new ProductCategoryListViewModel
            {
                SearchRequest = searchRequest ?? new ProductCategorySearchRequest()                
            });
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategoryModel productCategory)
        {
            try
            {
                if (productCategory.CategoryId == 0)
                {
                    productCategory.RecCreatedBy = User.Identity.Name;
                    productCategory.RecCreatedDate = DateTime.Now;
                }
                productCategory.RecLastUpdatedBy = User.Identity.Name;
                productCategory.RecLastUpdatedDate = DateTime.Now;


                if (productCategoryService.AddProductCategory(productCategory.CreateFromClientToServer()) > 0)
                {
                    //Product Saved
                    TempData["message"] = new MessageViewModel { Message = "Product category has been saved successfully.", IsSaved = true };
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
