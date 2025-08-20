using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Beequip.AcceptanceTests.Pages
{
    public class HomePage(IPage page)
    {
        public ILocator MenuMarketPlace => page.Locator("//a[contains(@class,'tw-group')][contains(.,'Marktplaats')]");

        public async Task GoTo()
        {
            await page.GotoAsync("");
            await page.WaitForLoadStateAsync();
        }


        public async Task NavigateToMarketPlaceAsync()
        {
            await MenuMarketPlace.ClickAsync();
            await page.WaitForLoadStateAsync();
        }
    }
}
