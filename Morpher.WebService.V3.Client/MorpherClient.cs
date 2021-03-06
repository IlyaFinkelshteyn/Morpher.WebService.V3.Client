﻿namespace Morpher.WebService.V3
{
    using System;

    public class MorpherClient
    {
        private readonly string url;

        private readonly Guid? token;

        public MorpherClient(Guid? token = null, string url = null)
        {
            this.token = token;
            this.url = url ?? "http://ws3.morpher.ru";
            this.Russian = new Russian.Client(NewClient);
            this.Ukrainian = new Ukrainian.Client(NewClient);
        }

        MyWebClient NewClient()
        {
            return new MyWebClient(token, url);
        }

        public Russian.Client Russian { get; }

        public Ukrainian.Client Ukrainian { get; }

        public int QueriesLeftForToday(Guid? guid = null)
        {
            using (var client = NewClient())
            {
                return client.GetObject<int>("/get_queries_left_for_today");
            }
        }
    }
}
