using Common.DynamicMenu.Entities;
using Common.DynamicMenu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CRMLite.UI.Helpers
{
    public static class DynamicMenuRenderingHelper
    {
        public static IList<MenuItem> _menuList = new List<MenuItem>();
        public static string _parentMenu = "";
        public static string _childMenu = "";
        public static string _innerChildMenu = "";
        public static bool _ulFlag = false;
        public static HtmlString BuildMenu(IList<MenuItem> menus)
        {
            var renderMenu = new StringBuilder();
            var addLi = new TagBuilder("li");
            _menuList = menus;
            var parentList=menus.Where(i=>i.ParentId==0).ToList();
            foreach (var menu in parentList)
            {
                addLi.InnerHtml = Render(menu);
                renderMenu.AppendLine(addLi.ToString());
            }
            return new HtmlString(renderMenu.ToString());
        }
        public static string Render(MenuItem menu)
        {
            var addUl = new TagBuilder("ul");
            var addLi = new TagBuilder("li");
            _parentMenu = RenderItem(menu);
            var childrens = _menuList.Where(i => i.ParentId == menu.Id).ToList();
            if (childrens.Count > 0)
            {
                foreach (var child in childrens)
                {
                    addLi.InnerHtml = RenderChild(child);
                    _childMenu += addLi;
                }
                addUl.AddCssClass("nav lt");
                addUl.InnerHtml = _childMenu.ToString();
                _childMenu = "";
                _parentMenu += addUl.ToString();
            }
            return _parentMenu;
        }
        public static string RenderChild(MenuItem menu)
        {
            var addLi = new TagBuilder("li");
            var addUl = new TagBuilder("ul");
            var innerMenu = "";
            //addLi.InnerHtml = RenderItem(menu);
            innerMenu = RenderItem(menu);
            var childrens = _menuList.Where(i => i.ParentId == menu.Id).ToList();
            if (childrens.Count > 0)
            {
                foreach (var child in childrens)
                {
                    _innerChildMenu += InnerChild(child);
                }
                addUl.AddCssClass("nav bg");
                addUl.InnerHtml = _innerChildMenu.ToString();
                _innerChildMenu = "";
                innerMenu += addUl.ToString();
            }
            return innerMenu.ToString();
        }
        public static string InnerChild(MenuItem menu)
        {
            var addLi = new TagBuilder("li");
            addLi.InnerHtml = RenderItem(menu);
            return addLi.ToString();
        }

        public static string RenderItem(MenuItem menu)
        {
            var template = menu.Template;
            if (menu.Action != "")
            {
                template = template.Replace("@Action", menu.Action);
                template = template.Replace("@Controller", menu.Controller);
                template = template.Replace("@Area", menu.Area);
                template = template.Replace("@Title", menu.Title);

            }
            else
            {
                template = template.Replace("@Title", menu.Title); ;
            }
            return template;
        }
       
    }
}