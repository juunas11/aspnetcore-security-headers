﻿using System.Collections.Generic;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspOptionsTests
    {
        [Fact]
        public void UpgradeInsecureRequests_ValueIsCorrect()
        {
            var options = new CspOptions
            {
                UpgradeInsecureRequests = true
            };

            string policy = options.ToString(null).headerValue;

            Assert.Equal("upgrade-insecure-requests", policy);
        }

        [Fact]
        public void UpgradeInsecureRequestsAndDefaultHttps_ValueIsCorrect()
        {
            var options = new CspOptions
            {
                UpgradeInsecureRequests = true,
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowOnlyHttps = true
                }
            };

            string policy = options.ToString(null).headerValue;

            Assert.Equal("upgrade-insecure-requests;default-src https:", policy);
        }

        [Fact]
        public void ManyOptions_ResultIsCorrect()
        {
            var options = new CspOptions
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowSelf = true
                },
                Img = new Csp.Options.CspImgSrcOptions
                {
                    AllowAny = true
                },
                Media = new Csp.Options.CspMediaSrcOptions
                {
                    AllowedSources = new List<string>
                    {
                        "media1.com",
                        "media2.com"
                    }
                },
                Script = new Csp.Options.CspScriptSrcOptions
                {
                    AllowedSources = new List<string>
                    {
                        "userscripts.example.com"
                    }
                }
            };

            var (headerName, headerValue) = options.ToString(null);

            Assert.Equal("Content-Security-Policy", headerName);
            Assert.Equal("default-src 'self';script-src userscripts.example.com;img-src *;media-src media1.com media2.com", headerValue);
        }

        [Fact]
        public void WorkerAndFrameOptions_ResultIsCorrect()
        {
            var options = new CspOptions
            {
                Frame = new CspFrameSrcOptions
                {
                    AllowAny = true
                },
                Worker = new CspWorkerSrcOptions
                {
                    AllowSelf = true
                }
            };

            var (headerName, headerValue) = options.ToString(null);

            Assert.Equal("Content-Security-Policy", headerName);
            Assert.Equal("frame-src *;worker-src 'self'", headerValue);
        }

        [Fact]
        public void WithoutReportOnly_HeaderNameIsCorrect()
        {
            var options = new CspOptions
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                }
            };

            var (headerName, _) = options.ToString(null);

            Assert.Equal("Content-Security-Policy", headerName);
        }

        [Fact]
        public void WithReportOnly_HeaderNameIsCorrect()
        {
            var options = new CspOptions
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                },
                ReportOnly = true
            };

            var (headerName, _) = options.ToString(null);

            Assert.Equal("Content-Security-Policy-Report-Only", headerName);
        }

        [Fact]
        public void BlockAllMixedContent_ValueIsCorrect()
        {
            var options = new CspOptions
            {
                BlockAllMixedContent = true
            };

            string policy = options.ToString(null).headerValue;

            Assert.Equal("block-all-mixed-content", policy);
        }
    }
}
