using System;
using System.Collections.Generic;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IAmazonDynamoDB client = new AmazonDynamoDBClient(RegionEndpoint.APSoutheast2))
            {
                Dictionary<string, AttributeValue> lastKeyEvaluated = null;
                do
                {
                    var request = new ScanRequest()
                    {
                        TableName = "Products",
                        ConsistentRead = true,
                        Limit = 10,
                        ExclusiveStartKey = lastKeyEvaluated
                    };

                    var response = client.Scan(request);

                    foreach (var responseItem in response.Items)
                    {
                        foreach (var attributeValue in responseItem)
                        {
                            Console.WriteLine(attributeValue.Value.S == null
                                ? $"{attributeValue.Key} : {attributeValue.Value.N}"
                                : $"{attributeValue.Key} : {attributeValue.Value.S}");
                        }
                        Console.WriteLine("");
                    }

                    lastKeyEvaluated = response.LastEvaluatedKey;
                } while (lastKeyEvaluated != null && lastKeyEvaluated.Count != 0);
            }
        }

        private static void PrintItems(ScanResponse response)
        {
            foreach (var responseItem in response.Items)
            {
                foreach (var attributeValue in responseItem)
                {
                    Console.WriteLine(attributeValue.Value.S == null
                        ? $"{attributeValue.Key} : {attributeValue.Value.N}"
                        : $"{attributeValue.Key} : {attributeValue.Value.S}");
                }
                Console.WriteLine("");
            }
        }
    }
}