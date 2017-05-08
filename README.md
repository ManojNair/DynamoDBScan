# DynamoDBScan
C# Code for DynamoDB Scan Operation with Limit of 10 items at a time
## Code Walkthrough
- Initialize the IAmazonDynamoDBClient Interface with a concrete implementation of the AmazonDynamoDB Client 
- Create a Scan Request with the following properties
  * TableName
  * Limit
  * LastEvaluatedKey
- [Code Sample](http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/LowLevelDotNetScanning.html)

## Key Points
- The Table in question is a sample Products DynamoDB table with only String and Number data types
- Hence, during the iteration, I check if the value contains either String or a Number as shown below:
```csharp
Console.WriteLine(attributeValue.Value.S == null
                                ? $"{attributeValue.Key} : {attributeValue.Value.N}"
                                : $"{attributeValue.Key} : {attributeValue.Value.S}")
```
