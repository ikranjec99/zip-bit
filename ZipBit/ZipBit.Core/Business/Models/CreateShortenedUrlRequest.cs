﻿namespace ZipBit.Core.Business.Models
{
    public class CreateShortenedUrlRequest
    {
        public long DomainId {  get; set; }
        
        public required string Url { get; set; }
    }
}
