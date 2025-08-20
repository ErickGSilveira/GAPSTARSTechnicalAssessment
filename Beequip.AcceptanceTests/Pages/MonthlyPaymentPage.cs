using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Pages
{
    public class MonthlyPaymentPage(IPage page)
    {   
        public ILocator inputdownPayment => page.Locator("//input[contains(@name, 'downPayment')]");
        public ILocator inputBalloonPayment => page.Locator("//input[contains(@name, 'balloonPayment')]");
        public ILocator inputDuration => page.Locator("//input[contains(@name, 'tenor')]");
        public ILocator btnPrimary => page.Locator("//button[contains(@kind, 'primary')]");
    }
}
