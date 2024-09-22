
namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        // Naming convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_String()
        {
            try
            {
                //Arrange - go get your variables, classes, functions and put them here
                int num = 0;
                WorldsDumbestFunction worldsDumbestFunction = new WorldsDumbestFunction();

                //Act - execute this function
                string result = worldsDumbestFunction.ReturnsPikachuIfZero(num);
                
                //Assert - whatever is returned, is it what you want?
                if(result == "PIKACHU")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
