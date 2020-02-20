﻿using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Infrastructure.Prism
{
    public class PanelHostRegionAdapter<T> : RegionAdapterBase<T>
        where T : Panel
    {
        public PanelHostRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, T regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement CurrentElement in e.OldItems)
                        regionTarget.Children.Remove(CurrentElement);
                }
            };
        }


        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
