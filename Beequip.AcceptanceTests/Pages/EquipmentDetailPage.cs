using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Beequip.AcceptanceTests.Pages
{
    public class EquipmentDetailPage(IPage page)
    {
        public ILocator btnLease => page.Locator("//a[@data-hook='lease-offer-button'][contains(.,'Maandbedrag berekenen')]");
    }
}
