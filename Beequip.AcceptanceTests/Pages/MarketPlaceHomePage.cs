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
            await Task.Delay(100);
            await MenuAllCategory.HoverAsync();
            await Task.Delay(100);
            await MenuAllCategory.HoverAsync();
            await page.Locator("//a[contains(@class,'cpRfQS')][contains(.,'Vrachtwagen')]").HoverAsync();
            await page.Locator("//a[contains(@class,'cpRfQS')][contains(.,'Schuifzeilen')]").ClickAsync();
            await page.WaitForLoadStateAsync();
        }
    }
}
