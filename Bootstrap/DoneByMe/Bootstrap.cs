using System;
using DoneByMe.Matching.Infra;
using DoneByMe.Pricing.Infra;

namespace DoneByMe.Bootstrap
{
    class Bootstrap
    {
        static void Main(string[] args)
        {
			DoneByMe.Matching.Infra.StartUp.Start();
			DoneByMe.Pricing.Infra.StartUp.Start();
        }
    }
}
