using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beequip.AcceptanceTests.Pages
{
    public class CompanySelectionPage(IPage page)
    {
        public ILocator inputCompany => page.Locator("//*[@id='cocNumber']");
        public ILocator ìtemList => page.Locator("//*[@id='downshift-0-item-0']");
        public ILocator inputEmail => page.Locator("//*[@id='CompanyForm']/*//input[contains(@name,'contactPersonEmail')]");
        public ILocator btnLease => page.Locator("//*[@id='submitCompanyForm']");
    }
}
