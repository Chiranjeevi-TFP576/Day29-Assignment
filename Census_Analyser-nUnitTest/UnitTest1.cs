using IndianStateCenSusAnaLyser;
using IndianStateCenSusAnaLyser.DTO;
using static IndianStateCenSusAnaLyser.CensusAnalyser;

namespace Census_Analyser_nUnitTest
{
    public class Tests
    {


        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string indianStateCodeFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string wrongIndianStateCensusFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string wrongIndianStateCensusFileType = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string delimiterIndianCensusFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string wrongIndianStateCodeFileType = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";
 
        static string wrongHeaderStateCodeFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";

        static string delimiterIndianstateCodeFilePath = @"D:\IndianStateCenSusAnaLyser\Census_Analyser-nUnitTest\UnitTest1.cs";





        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> TotalRecord;
        Dictionary<string, CensusDTO> StateRecord;


        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            TotalRecord = new Dictionary<string, CensusDTO>();
            StateRecord = new Dictionary<string, CensusDTO>();
        }

        //Test Case 1.1
        [Test]
        public void GivenStateCensusdataFile_WhenReaded_ShouldReturnStateCensusDataCount()
        {

            StateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, StateRecord.Count);

        }
        //Test Case 1.2

        [Test]
        public void GivenindianCensusdataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            //For Census Data
            int expected = 29;
            TotalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA,  indianStateCensusHeaders);
            Assert.AreEqual(expected, TotalRecord.Count);

        }
  
        //Test Case 1.3
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong Census data File
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA,  indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        //Test Case 1.4
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong Census Data File Type
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);

        }


        //Test Case 1.5
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }



        //UC2 
        //Test Case 2.1
        [Test]
        public void GivenIndianStateCodeFile_WhenReaded_ShouldReturnStateCodeDataCount()
        {
            //For State Code
            StateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA,  indianStateCodeHeaders);
            Assert.AreEqual(37, StateRecord.Count);

        }

        //Test Case 2.2
        [Test]
        public void GivenWrongIndianStateCensusFile_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong State Census File
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);

        }
        //Test Case 2.3
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            //Passing Wrong State Code File Type
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA,  indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);

        }

        //Test Case 2.4
        [Test]
        public void GivenIndianStateCodeFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianstateCodeFilePath, Country.INDIA,  indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        //Test Case 2.5
        [Test]
        public void GivenIndianStateCodeFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}