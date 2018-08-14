﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineExam.Framework;
using OnlineExam.NUnitTests.APIClients.Models;
using RestSharp;

namespace OnlineExam.NUnitTests.APIClients
{
    public class APICommentsClient : BaseAPIClient
    {


        public RestResultTyped<List<CommentsAPIModel>> Get(int id)
        {
            var request = new RestRequest($"/api/CommentApi?id={id}", Method.GET);
            var response = client.Execute(request);
            string jsonString = response.Content;
            List<CommentsAPIModel> result = JsonConvert.DeserializeObject<List<CommentsAPIModel>>(jsonString);
            return new RestResultTyped<List<CommentsAPIModel>>()
            {
                Code = response.StatusCode,
                Data = result
            };
        }

        public HttpStatusCode Post(Object obj)
        {
            var request = new RestRequest($"/api/CommentApi", Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(obj);
            var result = client.Execute(request);
            return result.StatusCode;
        }
    }
}