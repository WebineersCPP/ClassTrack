using ClassTrack.Models;
using ClassTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClassTrack.Tests
{
    public class HTMLToCurriculumSheetServiceTest
    {
        [Fact]
        public async void getCurriculumSheetShouldUseCatalogPhpService()
        {
            // CPP catalog domain
            string catalogPhpService = "catalog.cpp.edu/preview_program.php";

            string testUrl = "http://catalog.cpp.edu/preview_program.php?catoid=10&poid=2715&returnto=1210";

            HTMLToCurriculumSheetService testCSService = new HTMLToCurriculumSheetService();
            CurriculumSheet testCS = await testCSService.getCurriculumSheet(testUrl);

            Assert.True(testCSService.catalogLink.StartsWith("http://" + catalogPhpService) ||
                        testCSService.catalogLink.StartsWith("https://" + catalogPhpService) );
        }

        [Fact]
        public async void getCurriculumSheetShouldRejectNotLoadedUrl()
        {
            string testUrl = "http://cata--ERROR--log.cpp.edu/preview_program.php?catoid=10&poid=2715&returnto=1210";

            HTMLToCurriculumSheetService testCSService = new HTMLToCurriculumSheetService();

            Exception ex = await Assert.ThrowsAsync<Exception>(async () => await testCSService.getCurriculumSheet(testUrl));
            
            Assert.Equal("Error loading url", ex.Message);
        }
    }
}
