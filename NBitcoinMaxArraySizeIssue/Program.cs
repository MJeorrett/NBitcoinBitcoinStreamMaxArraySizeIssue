using NBitcoin;

namespace NBitcoinMaxArraySizeIssue
{
    class Program
    {
        static void Main(string[] _)
        {
            var payloadBytes = new byte[2 * 1024 * 1024];

            var nullDataTemplate = new TxNullDataTemplate(4194304);

            var txOut = new TxOut()
            {
                Value = Money.Zero,
                ScriptPubKey = nullDataTemplate.GenerateScriptPubKey(payloadBytes)
            };

            var tx = Transaction.Create(Network.TestNet);
            tx.Outputs.Add(txOut);

            tx.ToHex(); // this line fails
        }
    }
}
