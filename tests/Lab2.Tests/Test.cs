using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Cooler;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Configuration;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Test
{
    private Repository _repository = new Repository();

    [Fact]
    public void FineBuild()
    {
        ComputerCase computerCase = new ComputerCaseBuilder()
            .SetMaxLength(40)
            .SetMaxWidth(20)
            .AddSupportedFormFactor("ATX")
            .SetDimensions(15)
            .Build();
        Bios bios = new BiosBuilder()
            .SetType("UEFI")
            .SetVersion("2.0")
            .AddSupportedProcessor("Intel Core i7")
            .AddSupportedProcessor("AMD Ryzen 5")
            .Build();
        var connectionOptions = new Collection<string>();
        connectionOptions.Add("USB 3.0");
        connectionOptions.Add("HDMI");
        connectionOptions.Add("SATA 3.0");
        Motherboard motherboard = new MotherboardBuilder()
            .SetCpuSocket("LGA1200")
            .SetConnecttionOptions(connectionOptions)
            .SetSataPorts(6)
            .SetChipset("Intel B460")
            .AddSupportedMemoryFrequency("DDR4 3200 MHz")
            .AddXmpProfile("XMP Profile 1")
            .SetDdrStandard("DDR4")
            .SetRamSlots(4)
            .SetFormFactor("ATX")
            .SetBiosAttributes(bios)
            .Build();

        Cooler cooler = new CoolerBuilder()
            .SetDimensions("120mm x 120mm x 25mm")
            .AddSupportedSocket("LGA1200")
            .SetMaxTdpInWatts(1000)
            .Build();
        HardDrive hardDrive = new HardDriveBuilder()
            .SetCapacityInGB(1000)
            .SetSpindleSpeedInRPM(7200)
            .SetPowerConsumptionInWatts(8)
            .SetConnectionOptions("SATA 3.0")
            .Build();
        PowerUnit powerUnit = new PowerUnitBuilder()
            .SetPeakLoadInWatts(600)
            .Build();
        Processor processor = new ProcessorBuilder()
            .SetCoreFrequencyInGHz(3.5)
            .SetModel("Intel Core i7")
            .SetNumberOfCores(8)
            .SetSocket("LGA1200")
            .SetIntegratedGraphics(true)
            .AddSupportedMemoryFrequency("DDR4-3200")
            .SetThermalDesignPower(65)
            .SetPowerConsumptionInWatts(95)
            .Build();
        RamMemory ramMemory = new RamMemoryBuilder()
            .SetMemorySizeInGB(16)
            .AddSupportedJedecPair("DDR4-3200")
            .AddXmpProfile("XMP Profile 1")
            .AddFormFactor("DIMM")
            .SetDdrStandardVersion("DDR4")
            .SetPowerConsumptionInWatts(10)
            .Build();
        _repository.AddHardDrive(hardDrive);
        _repository.AddPowerUnit(powerUnit);
        _repository.AddCooler(cooler);
        _repository.AddMotherBoard(motherboard);
        _repository.AddComputerCase(computerCase);
        _repository.AddProcessor(processor);
        _repository.AddRamMemorie(ramMemory);
        Computer comp = new ComputerBuilder().SetComputerCase(computerCase).SetMotherboard(motherboard).SetBios(bios)
            .SetCooler(cooler)
            .SetPowerUnit(powerUnit).AddHardDrive(hardDrive).SetProcessor(processor).AddRamMemory(ramMemory).Build();
        ConfigurationResult result = new Configuration().Validate(comp);
        var complete = new ServiceAssembly(result);
        Assert.Equal(ResultBuild.Succes, complete.ResultBuild);
    }

    [Fact]
    public void EnergyUsageBuildToHigh()
    {
        ComputerCase computerCase = new ComputerCaseBuilder()
            .SetMaxLength(40)
            .SetMaxWidth(20)
            .AddSupportedFormFactor("ATX")
            .SetDimensions(15)
            .Build();
        Bios bios = new BiosBuilder()
            .SetType("UEFI")
            .SetVersion("2.0")
            .AddSupportedProcessor("Intel Core i7")
            .AddSupportedProcessor("AMD Ryzen 5")
            .Build();
        var connectionOptions = new Collection<string>();
        connectionOptions.Add("USB 3.0");
        connectionOptions.Add("HDMI");
        connectionOptions.Add("SATA 3.0");
        Motherboard motherboard = new MotherboardBuilder()
            .SetCpuSocket("LGA1200")
            .SetConnecttionOptions(connectionOptions)
            .SetSataPorts(6)
            .SetChipset("Intel B460")
            .AddSupportedMemoryFrequency("DDR4 3200 MHz")
            .AddXmpProfile("XMP Profile 1")
            .SetDdrStandard("DDR4")
            .SetRamSlots(4)
            .SetFormFactor("ATX")
            .SetBiosAttributes(bios)
            .Build();

        Cooler cooler = new CoolerBuilder()
            .SetDimensions("120mm x 120mm x 25mm")
            .AddSupportedSocket("LGA1200")
            .SetMaxTdpInWatts(100)
            .Build();
        HardDrive hardDrive = new HardDriveBuilder()
            .SetCapacityInGB(1000)
            .SetSpindleSpeedInRPM(7200)
            .SetPowerConsumptionInWatts(8)
            .SetConnectionOptions("SATA 3.0")
            .Build();
        PowerUnit powerUnit = new PowerUnitBuilder()
            .SetPeakLoadInWatts(100)
            .Build();
        Processor processor = new ProcessorBuilder()
            .SetCoreFrequencyInGHz(3.5)
            .SetModel("Intel Core i7")
            .SetNumberOfCores(8)
            .SetSocket("LGA1200")
            .SetIntegratedGraphics(true)
            .AddSupportedMemoryFrequency("DDR4-3200")
            .SetThermalDesignPower(65)
            .SetPowerConsumptionInWatts(95)
            .Build();
        RamMemory ramMemory = new RamMemoryBuilder()
            .SetMemorySizeInGB(16)
            .AddSupportedJedecPair("DDR4-3200")
            .AddXmpProfile("XMP Profile 1")
            .AddFormFactor("DIMM")
            .SetDdrStandardVersion("DDR4")
            .SetPowerConsumptionInWatts(10)
            .Build();
        Computer comp = new ComputerBuilder().SetComputerCase(computerCase).SetMotherboard(motherboard).SetBios(bios)
            .SetCooler(cooler)
            .SetPowerUnit(powerUnit).AddHardDrive(hardDrive).SetProcessor(processor).AddRamMemory(ramMemory).Build();
        ConfigurationResult result = new Configuration().Validate(comp);
        var complete = new ServiceAssembly(result);
        Assert.Equal(ResultBuild.Comment, complete.ResultBuild);
    }

    [Fact]
    public void TDPOfBuildToHigh()
    {
        ComputerCase computerCase = new ComputerCaseBuilder()
            .SetMaxLength(40)
            .SetMaxWidth(20)
            .AddSupportedFormFactor("ATX")
            .SetDimensions(15)
            .Build();
        Bios bios = new BiosBuilder()
            .SetType("UEFI")
            .SetVersion("2.0")
            .AddSupportedProcessor("Intel Core i7")
            .AddSupportedProcessor("AMD Ryzen 5")
            .Build();
        var connectionOptions = new Collection<string>();
        connectionOptions.Add("USB 3.0");
        connectionOptions.Add("HDMI");
        connectionOptions.Add("SATA 3.0");
        Motherboard motherboard = new MotherboardBuilder()
            .SetCpuSocket("LGA1200")
            .SetConnecttionOptions(connectionOptions)
            .SetSataPorts(6)
            .SetChipset("Intel B460")
            .AddSupportedMemoryFrequency("DDR4 3200 MHz")
            .AddXmpProfile("XMP Profile 1")
            .SetDdrStandard("DDR4")
            .SetRamSlots(4)
            .SetFormFactor("ATX")
            .SetBiosAttributes(bios)
            .Build();

        Cooler cooler = new CoolerBuilder()
            .SetDimensions("120mm x 120mm x 25mm")
            .AddSupportedSocket("LGA1200")
            .SetMaxTdpInWatts(1)
            .Build();
        HardDrive hardDrive = new HardDriveBuilder()
            .SetCapacityInGB(1000)
            .SetSpindleSpeedInRPM(7200)
            .SetPowerConsumptionInWatts(8)
            .SetConnectionOptions("SATA 3.0")
            .Build();
        PowerUnit powerUnit = new PowerUnitBuilder()
            .SetPeakLoadInWatts(600)
            .Build();
        Processor processor = new ProcessorBuilder()
            .SetCoreFrequencyInGHz(3.5)
            .SetModel("Intel Core i7")
            .SetNumberOfCores(8)
            .SetSocket("LGA1200")
            .SetIntegratedGraphics(true)
            .AddSupportedMemoryFrequency("DDR4-3200")
            .SetThermalDesignPower(65)
            .SetPowerConsumptionInWatts(95)
            .Build();
        RamMemory ramMemory = new RamMemoryBuilder()
            .SetMemorySizeInGB(16)
            .AddSupportedJedecPair("DDR4-3200")
            .AddXmpProfile("XMP Profile 1")
            .AddFormFactor("DIMM")
            .SetDdrStandardVersion("DDR4")
            .SetPowerConsumptionInWatts(10)
            .Build();
        Computer comp = new ComputerBuilder().SetComputerCase(computerCase).SetMotherboard(motherboard).SetBios(bios)
            .SetCooler(cooler)
            .SetPowerUnit(powerUnit).AddHardDrive(hardDrive).SetProcessor(processor).AddRamMemory(ramMemory).Build();
        ConfigurationResult result = new Configuration().Validate(comp);
        var complete = new ServiceAssembly(result);
        Assert.Equal(ResultBuild.Comment, complete.ResultBuild);
    }

    [Fact]
    public void ComponentsBuildIncompatible()
    {
        ComputerCase computerCase = new ComputerCaseBuilder()
            .SetMaxLength(40)
            .SetMaxWidth(20)
            .AddSupportedFormFactor("ATX")
            .SetDimensions(15)
            .Build();
        Bios bios = new BiosBuilder()
            .SetType("UEFI")
            .SetVersion("2.0")
            .AddSupportedProcessor("Intel Core i7")
            .AddSupportedProcessor("AMD Ryzen 5")
            .Build();
        var connectionOptions = new Collection<string>();
        connectionOptions.Add("USB 3.0");
        connectionOptions.Add("HDMI");
        connectionOptions.Add("SATA 3.0");
        Motherboard motherboard = new MotherboardBuilder()
            .SetCpuSocket("LGA1200")
            .SetConnecttionOptions(connectionOptions)
            .SetSataPorts(6)
            .SetChipset("Intel B460")
            .AddSupportedMemoryFrequency("DDR4 3200 MHz")
            .AddXmpProfile("XMP Profile 1")
            .SetDdrStandard("DDR4")
            .SetRamSlots(4)
            .SetFormFactor("ATX")
            .SetBiosAttributes(bios)
            .Build();

        Cooler cooler = new CoolerBuilder()
            .SetDimensions("120mm x 120mm x 25mm")
            .AddSupportedSocket("LGA1200")
            .SetMaxTdpInWatts(1)
            .Build();
        HardDrive hardDrive = new HardDriveBuilder()
            .SetCapacityInGB(1000)
            .SetSpindleSpeedInRPM(7200)
            .SetPowerConsumptionInWatts(8)
            .SetConnectionOptions("SATA 3.0")
            .Build();
        PowerUnit powerUnit = new PowerUnitBuilder()
            .SetPeakLoadInWatts(600)
            .Build();
        Processor processor = new ProcessorBuilder()
            .SetCoreFrequencyInGHz(3.5)
            .SetModel("Intel Core i7")
            .SetNumberOfCores(8)
            .SetSocket("AMD3.09")
            .SetIntegratedGraphics(true)
            .AddSupportedMemoryFrequency("DDR4-3200")
            .SetThermalDesignPower(65)
            .SetPowerConsumptionInWatts(95)
            .Build();
        RamMemory ramMemory = new RamMemoryBuilder()
            .SetMemorySizeInGB(16)
            .AddSupportedJedecPair("DDR4-3200")
            .AddXmpProfile("XMP Profile 1")
            .AddFormFactor("DIMM")
            .SetDdrStandardVersion("DDR4")
            .SetPowerConsumptionInWatts(10)
            .Build();
        Computer comp = new ComputerBuilder().SetComputerCase(computerCase).SetMotherboard(motherboard).SetBios(bios)
            .SetCooler(cooler)
            .SetPowerUnit(powerUnit).AddHardDrive(hardDrive).SetProcessor(processor).AddRamMemory(ramMemory).Build();
        ConfigurationResult result = new Configuration().Validate(comp);
        var complete = new ServiceAssembly(result);
        Assert.Equal(ResultBuild.Refusel, complete.ResultBuild);
    }
}