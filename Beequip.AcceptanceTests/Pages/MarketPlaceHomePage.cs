using Beequip.AcceptanceTests.Support.DataTableHelper;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Pages
{
    public class MarketPlaceHomePage(IPage page)
    {
        public ILocator MenuAllCategory => page.Locator("//button[contains(.,'Alle categorieën')]");

        public async Task SelectSubcategory(EquipmentLeaseRequest equipmentLeaseRequest)
        {
            //for (int i = 0; i < 5; i++)
            // {
            await Task.Delay(100);
            await MenuAllCategory.HoverAsync();
            await Task.Delay(100);
            await MenuAllCategory.HoverAsync();
               // if(await MenuAllCategory.GetAttributeAsync("data-state") == "open")
                 //   break;
           // }
            await page.Locator("//a[contains(@class,'cpRfQS')][contains(.,'Vrachtwagen')]").HoverAsync();
            await page.Locator("//a[contains(@class,'cpRfQS')][contains(.,'Schuifzeilen')]").ClickAsync();
            await page.WaitForLoadStateAsync();
        }
    }
}
