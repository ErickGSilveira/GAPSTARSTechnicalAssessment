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
        public ILocator menuMarktplace => page.Locator("//a[contains(@class,'tw-group')][contains(.,'Marktplaats')]");

    }
}
