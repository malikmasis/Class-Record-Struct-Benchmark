using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();


[MemoryDiagnoser]
public class MemoryBenchmarkerDemo
{
    readonly List<string> giftCodes = new(1_000_000);

    public MemoryBenchmarkerDemo()
    {
        for (var i = 0; i < giftCodes.Capacity; i++)
        {
            giftCodes.Add("Random");
        }
    }

    [Benchmark]
    public void UseRecord()
    {
        var giftCodeList = new List<GiftCodeRecord>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(new GiftCodeRecord
            {
                Code = giftCodes.ElementAt(i),
                Amount = 50,
                Desc = "Aciklama",
                Partner = "Partner",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                CreatorId = 1
            });
        }
    }

    [Benchmark]
    public void UseRecordWithKeyword()
    {
        var giftCode = new GiftCodeRecord
        {
            Amount = 50,
            Desc = "Aciklama",
            Partner = "Partner",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddYears(1),
            CreatorId = 1
        };

        var giftCodeList = new List<GiftCodeRecord>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(giftCode with { Code = giftCodes.ElementAt(i) });
        }
    }

    [Benchmark]
    public void UseClass()
    {
        var giftCodeList = new List<GiftCodeClass>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(new GiftCodeClass
            {
                Code = giftCodes.ElementAt(i),
                Amount = 50,
                Desc = "Aciklama",
                Partner = "Partner",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                CreatorId = 1
            });
        }
    }

    [Benchmark]
    public void UseStruct()
    {
        var giftCodeList = new List<GiftCodeStruct>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(new GiftCodeStruct
            {
                Code = giftCodes.ElementAt(i),
                Amount = 50,
                Desc = "Aciklama",
                Partner = "Partner",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                CreatorId = 1
            });
        }
    }

    [Benchmark]
    public void UseStructWithKeyword()
    {
        var giftCode = new GiftCodeStruct
        {
            Amount = 50,
            Desc = "Aciklama",
            Partner = "Partner",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddYears(1),
            CreatorId = 1
        };

        var giftCodeList = new List<GiftCodeStruct>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(giftCode with { Code = giftCodes.ElementAt(i) });
        }
    }

    [Benchmark]
    public void UseRecordStruct()
    {
        var giftCodeList = new List<GiftCodeRecordStruct>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(new GiftCodeRecordStruct
            {
                Code = giftCodes.ElementAt(i),
                Amount = 50,
                Desc = "Aciklama",
                Partner = "Partner",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                CreatorId = 1
            });
        }
    }

    [Benchmark]
    public void UseRecordStructWithKeyword()
    {
        var giftCode = new GiftCodeRecordStruct
        {
            Amount = 50,
            Desc = "Aciklama",
            Partner = "Partner",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddYears(1),
            CreatorId = 1
        };

        var giftCodeList = new List<GiftCodeRecordStruct>();

        for (var i = 0; i < giftCodes.Count; i++)
        {
            giftCodeList.Add(giftCode with { Code = giftCodes.ElementAt(i) });
        }
    }


    public sealed record GiftCodeRecord 
    {
        public string Code { get; init; }

        public decimal Amount { get; init; }

        public string Desc { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public string Partner { get; init; }

        public int CreatorId { get; init; }
    }

    public record struct GiftCodeRecordStruct
    {
        public string Code { get; init; }

        public decimal Amount { get; init; }

        public string Desc { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public string Partner { get; init; }

        public int CreatorId { get; init; }
    }

    public sealed class GiftCodeClass
    {
        public string Code { get; init; }

        public decimal Amount { get; init; }

        public string Desc { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public string Partner { get; init; }

        public int CreatorId { get; init; }
    }

    public struct GiftCodeStruct
    {
        public string Code { get; init; }

        public decimal Amount { get; init; }

        public string Desc { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public string Partner { get; init; }

        public int CreatorId { get; init; }
    }
}


