using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Pages
{
    public class EquipmentListPage(IPage page)
    {
        public ILocator btnYearOfConstruction => page.Locator("//legend[@type='button'][contains(.,'Bouwjaar')]");
        public ILocator inputFromYear => page.Locator("//input[@data-hook='aggregation-yearOfConstruction-from']");
        public ILocator inputToYear => page.Locator("//input[@data-hook='aggregation-yearOfConstruction-to']");
        public ILocator btnOk => page.Locator("//button[@type='submit'][contains(.,'Ok')]");
        public ILocator btnKm => page.Locator("//legend[@type='button'][contains(.,'Kilometerstand')]");
        public ILocator inputToKm => page.Locator("//input[contains(@data-hook,'aggregation-usageInKilometers-to')]");
        public ILocator btnCylinders => page.Locator("//legend[@type='button'][contains(.,'Aantal cilinders')]");
        public ILocator checkBoxCylinders => page.Locator("//span[@data-hook='aggregation-label'][contains(.,'6')]");

        public async Task Filter()
        {
            await btnYearOfConstruction.ClickAsync();
            await inputFromYear.FillAsync("2018");
            await inputToYear.FillAsync("2023");
            await btnOk.ClickAsync();
            await page.WaitForLoadStateAsync();
            await btnYearOfConstruction.ClickAsync();

            await btnKm.ClickAsync();
            await inputToKm.FillAsync("300000");
            await btnOk.ClickAsync();
            await page.WaitForLoadStateAsync();
            await btnKm.ClickAsync();

            await btnCylinders.ClickAsync();
            await checkBoxCylinders.ClickAsync();
            await page.WaitForLoadStateAsync();

            await page.Locator("//article").First.ClickAsync();
        }
    }
}
