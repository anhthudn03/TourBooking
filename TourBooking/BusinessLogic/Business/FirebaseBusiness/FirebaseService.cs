﻿using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Configuration;
using BusinessLogic.Repostitory;
using BusinessLogic.Dtos.FirebaseaDto;
using static BusinessLogic.Configuration.ConfigurationModel;
using Firebase.Auth;
using Firebase.Storage;

namespace BusinessLogic.Business.FirebaseBusiness
{
    public class FirebaseService : GenericBackendService
    {
        ///private readonly IConverter _pdfConverter;
        private AppActionResult _result;
        private FirebaseConfiguration _firebaseConfiguration;
        private readonly IConfiguration _configuration;
        public FirebaseService(IServiceProvider serviceProvider, IConfiguration configuration, FirebaseConfiguration firebaseConfiguration) : base(serviceProvider)
        {
            //_pdfConverter = pdfConverter;
            _result = new();
            _firebaseConfiguration = firebaseConfiguration;
            _configuration = configuration;
        }

        public async Task<AppActionResult> DeleteFileFromFirebase(string pathFileName)
        {
            var _result = new AppActionResult();
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
                var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                var storage = new FirebaseStorage(
             _firebaseConfiguration.Bucket,
             new FirebaseStorageOptions
             {
                 AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                 ThrowOnCancel = true
             });
                await storage
                    .Child(pathFileName)
                    .DeleteAsync();
                _result.Messages.Add("Delete image successful");
                _result.IsSuccess = true;
            }
            catch (FirebaseStorageException ex)
            {
                _result.Messages.Add($"Error deleting image: {ex.Message}");
            }
            return _result;
        }

        //public async Task<string> GetUrlImageFromFirebase(string pathFileName)
        //{
        //    //var a = pathFileName.Split("/");
        //    var a = pathFileName.Split("/o/")[1];
        //    //pathFileName = $"{a[0]}%2F{a[1]}";
        //    var api = $"https://firebasestorage.googleapis.com/v0/b/cloudfunction-yt-2b3df.appspot.com/o?name={a}";
        //    if (string.IsNullOrEmpty(pathFileName))
        //    {
        //        return string.Empty;
        //    }

        //    var client = new RestClient();
        //    var request = new RestRequest(api);
        //    var response = client.Execute(request);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var jmessage = JObject.Parse(response.Content);
        //        var downloadToken = jmessage.GetValue("downloadTokens").ToString();
        //        return
        //            $"https://firebasestorage.googleapis.com/v0/b/{_configuration["cloudfunction-yt-2b3df.appspot.com"]}/o/{pathFileName}?alt=media&token={downloadToken}";
        //    }

        //    return string.Empty;
        //}

        public async Task<AppActionResult> UploadFileToFirebase(IFormFile file, string pathFileName)
        {
            var _result = new AppActionResult();
            bool isValid = true;
            if (file == null || file.Length == 0)
            {
                isValid = false;
                _result.Messages.Add("The file is empty");
            }
            if (isValid)
            {
                var stream = file!.OpenReadStream();
                var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
                var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
                string destinationPath = $"{pathFileName}";

                var task = new FirebaseStorage(
                _firebaseConfiguration.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(destinationPath)
                .PutAsync(stream);
                var downloadUrl = await task;

                if (task != null)
                {
                    _result.Result = downloadUrl;
                }
                else
                {
                    _result.IsSuccess = false;
                    _result.Messages.Add("Upload failed");
                }
            }
            return _result;
        }
        public async Task<AppActionResult> UploadFilesToFirebase(List<IFormFile> files, string basePath)
        {
            var _result = new AppActionResult();
            var uploadResults = new List<string>();

            var auth = new FirebaseAuthProvider(new FirebaseConfig(_firebaseConfiguration.ApiKey));
            var account = await auth.SignInWithEmailAndPasswordAsync(_firebaseConfiguration.AuthEmail, _firebaseConfiguration.AuthPassword);
            var storage = new FirebaseStorage(
                _firebaseConfiguration.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(account.FirebaseToken),
                    ThrowOnCancel = true
                });

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    _result.Messages.Add("One or more files are empty");
                    continue;
                }

                var stream = file.OpenReadStream();
                string destinationPath = $"{basePath}/{file.FileName}";

                var task = storage.Child(destinationPath).PutAsync(stream);
                var downloadUrl = await task;

                if (task != null)
                {
                    uploadResults.Add(downloadUrl);
                }
                else
                {
                    _result.IsSuccess = false;
                    _result.Messages.Add($"Upload failed for file: {file.FileName}");
                }
            }

            _result.Result = uploadResults;
            if (uploadResults.Count == files.Count)
            {
                _result.IsSuccess = true;
                _result.Messages.Add("All files uploaded successfully");
            }
            else
            {
                _result.IsSuccess = false;
                _result.Messages.Add("Some files failed to upload");
            }

            return _result;
        }
    }
}
