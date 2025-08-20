using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Pages
{
    public class LeaseSendPage(IPage page)
    {
        public ILocator inputName => page.Locator("//input[contains(@name, 'name')]");
        public ILocator inputBalloonPhone => page.Locator("//input[contains(@name, 'phone')]");
        public ILocator radioMorning => page.GetByText("Ochtend");
        public ILocator btnPrimary => page.Locator("//button[contains(@kind, 'primary')]");
    }
}
