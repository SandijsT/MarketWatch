using SSWebScraper.Contexts;
using DatabaseLibrary.Models;
using System.Reflection;
using System.Text.Json;

namespace SSWebScraper.Data
{
    public class ResourceContextSeed
    {
        public static async Task SeedAsync(resourceContext resourceContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!resourceContext.Lumodels.Any())
                {
                    var modelData = File.ReadAllText(path + @"/Data/SeedData/LUModel.json");
                    var models = JsonSerializer.Deserialize<List<Lumodel>>(modelData);

                    foreach (var item in models)
                    {
                        resourceContext.Lumodels.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if(!resourceContext.ModelLanguages.Any())
                {
                    var modelLanguageData = File.ReadAllText(path + @"/Data/SeedData/ModelLanguage.json");
                    var modelLanguages = JsonSerializer.Deserialize<List<ModelLanguage>>(modelLanguageData);
                    foreach (var item in modelLanguages)
                    {
                        resourceContext.ModelLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.LubodyTypes.Any())
                {
                    var bodyTypeData = File.ReadAllText(path + @"/Data/SeedData/LUBodyType.json");
                    var bodyTpes = JsonSerializer.Deserialize<List<LubodyType>>(bodyTypeData);
                    foreach (var item in bodyTpes)
                    {
                        resourceContext.LubodyTypes.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.BodyTypeLanguages.Any())
                {
                    var bodyTypeLanguageData = File.ReadAllText(path + @"/Data/SeedData/BodyTypeLanguage.json");
                    var bodyTypeLanguages = JsonSerializer.Deserialize<List<BodyTypeLanguage>>(bodyTypeLanguageData);
                    foreach (var item in bodyTypeLanguages)
                    {
                        resourceContext.BodyTypeLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.Lucategories.Any())
                {
                    var categoryData = File.ReadAllText(path + @"/Data/SeedData/LUCategory.json");
                    var categoies = JsonSerializer.Deserialize<List<Lucategory>>(categoryData);
                    foreach (var item in categoies)
                    {
                        resourceContext.Lucategories.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.CategoryLanguages.Any())
                {
                    var categoryLanguageData = File.ReadAllText(path + @"/Data/SeedData/CategoryLanguage.json");
                    var categoryLanguages = JsonSerializer.Deserialize<List<CategoryLanguage>>(categoryLanguageData);
                    foreach (var item in categoryLanguages)
                    {
                        resourceContext.CategoryLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.LuengineDisplacementTypes.Any())
                {
                    var engineDisplacementTypeData = File.ReadAllText(path + @"/Data/SeedData/LUEngineDisplacementType.json");
                    var engineDisplacementTypes = JsonSerializer.Deserialize<List<LuengineDisplacementType>>(engineDisplacementTypeData);
                    foreach (var item in engineDisplacementTypes)
                    {
                        resourceContext.LuengineDisplacementTypes.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.EngineDisplacementTypeLanguages.Any())
                {
                    var engineDisplacementTypeLanguageData = File.ReadAllText(path + @"/Data/SeedData/EngineDisplacementTypeLanguage.json");
                    var engineDisplacementTypeLanguages = JsonSerializer.Deserialize<List<EngineDisplacementTypeLanguage>>(engineDisplacementTypeLanguageData);
                    foreach (var item in engineDisplacementTypeLanguages)
                    {
                        resourceContext.EngineDisplacementTypeLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.LufuelTypes.Any())
                {
                    var FuelTypeData = File.ReadAllText(path + @"/Data/SeedData/LUFuelType.json");
                    var fuelTypes = JsonSerializer.Deserialize<List<LufuelType>>(FuelTypeData);
                    foreach (var item in fuelTypes)
                    {
                        resourceContext.LufuelTypes.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.FuelTypeLanguages.Any())
                {
                    var fuelTypeLanguageData = File.ReadAllText(path + @"/Data/SeedData/FuelTypeLanguage.json");
                    var fuelTypeLanguages = JsonSerializer.Deserialize<List<FuelTypeLanguage>>(fuelTypeLanguageData);
                    foreach (var item in fuelTypeLanguages)
                    {
                        resourceContext.FuelTypeLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.LupostTypes.Any())
                {
                    var postTypeData = File.ReadAllText(path + @"/Data/SeedData/LUPostType.json");
                    var postTypes = JsonSerializer.Deserialize<List<LupostType>>(postTypeData);
                    foreach (var item in postTypes)
                    {
                        resourceContext.LupostTypes.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.PostTypeLanguages.Any())
                {
                    var postTypeLanguagesData = File.ReadAllText(path + @"/Data/SeedData/PostTypeLanguage.json");
                    var PostTypeLanguages = JsonSerializer.Deserialize<List<PostTypeLanguage>>(postTypeLanguagesData);
                    foreach (var item in PostTypeLanguages)
                    {
                        resourceContext.PostTypeLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.LutransmissionTypes.Any())
                {
                    var transmissionTypeData = File.ReadAllText(path + @"/Data/SeedData/LUTransmissionType.json");
                    var transmissionTypes = JsonSerializer.Deserialize<List<LutransmissionType>>(transmissionTypeData);
                    foreach (var item in transmissionTypes)
                    {
                        resourceContext.LutransmissionTypes.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }

                if (!resourceContext.TransmissionTypeLanguages.Any())
                {
                    var transmissionTypeLanguageData = File.ReadAllText(path + @"/Data/SeedData/TransmissionTypeLanguage.json");
                    var transmissionTypeLanguages = JsonSerializer.Deserialize<List<TransmissionTypeLanguage>>(transmissionTypeLanguageData);
                    
                    foreach (var item in transmissionTypeLanguages)
                    {
                        resourceContext.TransmissionTypeLanguages.Add(item);
                    }

                    await resourceContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            { 
                var logger = loggerFactory.CreateLogger<ResourceContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
