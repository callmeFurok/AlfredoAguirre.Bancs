﻿namespace AA.Bancs.Transversal.Commom
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}