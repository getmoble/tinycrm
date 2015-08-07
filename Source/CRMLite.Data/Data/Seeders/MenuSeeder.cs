using Common.DynamicMenu.Entities;
using System.Collections.Generic;

namespace CRMLite.Data.Data.Seeders
{
    public static class MenuSeeder
    {
        public static void Seed(DataContext context)
        {
            var menu = new List<MenuItem>
            {
                new MenuItem{Action="Index",Controller="Home",Title="Dashboard",Area="CRM",Permission=111,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-dashboard icon\"> <b class=\"bg-danger\"></b> </i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Properties",Area="ERP",Permission=213,Template="<a href=\"#layout\"> <i class=\"fa fa-columns icon\"> <b class=\"bg-warning\"></b> </i> <span class=\"pull-right\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> </span> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Portfolio",Area="ERP",ParentId=2,Permission=213,Template="<a href=\"#\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Index",Controller="Portfolio",Title="Manage",Area="ERP",ParentId=3,Permission=104,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Portfolio",Title="Create",Area="ERP",ParentId=3,Permission=105,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Property",Area="ERP",ParentId=2,Permission=213,Template="<a href=\"#\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Index",Controller="Property",Title="Manage",Area="ERP",ParentId=6,Permission=100,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Property",Title="Create",Area="ERP",ParentId=6,Permission=101,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Unit",Area="ERP",ParentId=2,Permission=213,Template="<a href=\"#\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Index",Controller="Unit",Title="Manage",Area="ERP",ParentId=9,Permission=102,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Unit",Title="Create",Area="ERP",ParentId=9,Permission=103,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Owner",Area="ERP",ParentId=2,Permission=213,Template="<a href=\"#\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Index",Controller="Owner",Title="Manage",Area="ERP",ParentId=12,Permission=106,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Owner",Title="Create",Area="ERP",ParentId=12,Permission=107,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Manager",Area="ERP",ParentId=2,Permission=213,Template="<a href=\"#\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Index",Controller="Manager",Title="Manage",Area="ERP",ParentId=15,Permission=108,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Manager",Title="Create",Area="ERP",ParentId=15,Permission=109,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="CRM",Permission=213,Template="<a href=\"#layout1\"> <i class=\"fa fa-columns icon\"> <b class=\"bg-warning\"></b> </i> <span class=\"pull-right\"> <i class=\"fa fa-angle-down text\"></i> <i class=\"fa fa-angle-up text-active\"></i> </span> <span>@Title</span> </a>"},
                new MenuItem{Action="",Controller="",Title="Leads",Area="CRM",ParentId=18,Permission=213,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-columns icon\"> <b class=\"bg-warning\"></b> </i>  <span>@Title</span> </a>"},

                new MenuItem{Action="Index",Controller="Lead",Title="Manage",Area="CRM",ParentId=19,Permission=202,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Lead",Title="Create",Area="CRM",ParentId=19,Permission=203,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},


                new MenuItem{Action="",Controller="",Title="Accounts",Area="CRM",ParentId=18,Permission=213,Template=" <a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-dollar\"> <b class=\"bg-success\"></b> </i> <span>@Title</span> </a> "},

                new MenuItem{Action="Index",Controller="Account",Title="Manage",Area="CRM",ParentId=22,Permission=200,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Account",Title="Create",Area="CRM",ParentId=22,Permission=201,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},

                new MenuItem{Action="",Controller="",Title="Contacts",Area="CRM",ParentId=18,Permission=213,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-envelope\"> <b class=\"bg-primary\"></b> </i> <span>@Title</span> </a>"},

                new MenuItem{Action="Index",Controller="Contact",Title="Manage",Area="CRM",ParentId=25,Permission=204,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Contact",Title="Create",Area="CRM",ParentId=25,Permission=205,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},

                new MenuItem{Action="",Controller="",Title="Potentials",Area="CRM",ParentId=18,Permission=213,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-envelope-o icon\"><b class=\"bg-dark\"></b> </i> <span>@Title</span> </a> "},

                new MenuItem{Action="Index",Controller="Potential",Title="Manage",Area="CRM",ParentId=28,Permission=206,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="Potential",Title="Create",Area="CRM",ParentId=28,Permission=207,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},

                new MenuItem{Action="",Controller="",Title="Users",Area="CRM",ParentId=18,Permission=213,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-users\"> <b class=\"bg-info\"></b> </i> <span>@Title</span> </a>"},

                new MenuItem{Action="Index",Controller="User",Title="Manage",Area="CRM",ParentId=31,Permission=208,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"},
                new MenuItem{Action="Create",Controller="User",Title="Create",Area="CRM",ParentId=31,Permission=209,Template="<a href=\"/@Area/@Controller/@Action\"> <i class=\"fa fa-angle-right\"></i> <span>@Title</span> </a>"}
            };
            menu.ForEach(s => context.MenuItems.Add(s));
            context.SaveChanges();
        }
    }
}
