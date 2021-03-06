﻿using Orchard.Environment.Extensions;
using Orchard.Mvc.Routes;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
namespace Moov2.Orchard.SEO
{
    [OrchardFeature("Moov2.Orchard.SEO.Robots")]
    public class RoutesRobots : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "robots.txt",
                        new RouteValueDictionary {
                            {"area", "Moov2.Orchard.SEO"},
                            {"controller", "Robots"},
                            {"action", "GetRobots"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Moov2.Orchard.SEO"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }

    [OrchardFeature("Moov2.Orchard.SEO.Favicon")]
    public class RoutesFavicon : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "favicon.ico",
                        new RouteValueDictionary {
                            {"area", "Moov2.Orchard.SEO"},
                            {"controller", "Favicon"},
                            {"action", "GetFavicon"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Moov2.Orchard.SEO"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}