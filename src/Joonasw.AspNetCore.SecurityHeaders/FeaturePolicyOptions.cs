using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class FeaturePolicyOptions
    {
        public FeaturePolicyOptions()
        {
            Geolocation = new FeaturePolicyGeolocationOptions();
            Midi = new FeaturePolicyMidiOptions();
            Notifications = new FeaturePolicyNotificationsOptions();
            Push = new FeaturePolicyPushOptions();
            SyncXhr = new FeaturePolicySyncXhrOptions();
            Microphone = new FeaturePolicyMicrophoneOptions();
            Camera = new FeaturePolicyCameraOptions();
            Magnetometer = new FeaturePolicyMagnetometerOptions();
            Gyroscope = new FeaturePolicyGyroscopeOptions();
            Speaker = new FeaturePolicySpeakerOptions();
            Vibrate = new FeaturePolicyVibrateOptions();
            Fullscreen = new FeaturePolicyFullscreenOptions();
            Payment = new FeaturePolicyPaymentOptions();
            Accelerometer = new FeaturePolicyAccelerometerOptions();
            AmbientLightSensor = new FeaturePolicyAmbientLightSensorOptions();
            Autoplay = new FeaturePolicyAutoplayOptions();
            EncryptedMedia = new FeaturePolicyEncryptedMediaOptions();
            PictureInPicture = new FeaturePolicyPictureInPictureOptions();
            Usb = new FeaturePolicyUsbOptions();
            Vr = new FeaturePolicyVrOptions();
            Other = new Dictionary<string, FeaturePolicyOptionsBase>();
        }

        public FeaturePolicyOptionsBase Geolocation { get; set; }
        public FeaturePolicyOptionsBase Midi { get; set; }
        public FeaturePolicyOptionsBase Notifications { get; set; }
        public FeaturePolicyOptionsBase Push { get; set; }
        public FeaturePolicyOptionsBase SyncXhr { get; set; }
        public FeaturePolicyOptionsBase Microphone { get; set; }
        public FeaturePolicyOptionsBase Camera { get; set; }
        public FeaturePolicyOptionsBase Magnetometer { get; set; }
        public FeaturePolicyOptionsBase Gyroscope { get; set; }
        public FeaturePolicyOptionsBase Speaker { get; set; }
        public FeaturePolicyOptionsBase Vibrate { get; set; }
        public FeaturePolicyOptionsBase Fullscreen { get; set; }
        public FeaturePolicyOptionsBase Payment { get; set; }
        public FeaturePolicyOptionsBase Accelerometer { get; set; }
        public FeaturePolicyOptionsBase AmbientLightSensor { get; set; }
        public FeaturePolicyOptionsBase Autoplay { get; set; }
        public FeaturePolicyOptionsBase EncryptedMedia { get; set; }
        public FeaturePolicyOptionsBase PictureInPicture { get; set; }
        public FeaturePolicyOptionsBase Usb { get; set; }
        public FeaturePolicyOptionsBase Vr { get; set; }
        public Dictionary<string, FeaturePolicyOptionsBase> Other { get; set; }

        internal enum FeaturePolicyValue
        {
            [DefaultValue("geolocation")]
            Geolocation = 0,
            [DefaultValue("midi")]
            Midi = 1,
            [DefaultValue("notifications")]
            Notifications = 2,
            [DefaultValue("push")]
            Push = 3,
            [DefaultValue("sync-xhr")]
            SyncXhr = 4,
            [DefaultValue("microphone")]
            Microphone = 5,
            [DefaultValue("camera")]
            Camera = 6,
            [DefaultValue("magnetometer")]
            Magnetometer = 7,
            [DefaultValue("gyroscope")]
            Gyroscope = 8,
            [DefaultValue("speaker")]
            Speaker = 9,
            [DefaultValue("vibrate")]
            Vibrate = 10,
            [DefaultValue("fullscreen")]
            Fullscreen = 11,
            [DefaultValue("payment")]
            Payment = 12,
            [DefaultValue("accelerometer")]
            Accelerometer = 13,
            [DefaultValue("ambient-light-sensor")]
            AmbientLightSensor = 14,
            [DefaultValue("autoplay")]
            Autoplay = 15,
            [DefaultValue("encrypted-media")]
            EncryptedMedia = 16,
            [DefaultValue("picture-in-picture")]
            PictureInPicture = 17,
            [DefaultValue("usb")]
            Usb = 18,
            [DefaultValue("vr")]
            Vr = 19
        }

        public override string ToString()
        {
            var optionValues = new List<string>
            {
                Geolocation.ToString(),
                Midi.ToString(),
                Notifications.ToString(),
                Push.ToString(),
                SyncXhr.ToString(),
                Microphone.ToString(),
                Camera.ToString(),
                Magnetometer.ToString(),
                Gyroscope.ToString(),
                Speaker.ToString(),
                Vibrate.ToString(),
                Fullscreen.ToString(),
                Payment.ToString(),
                Accelerometer.ToString(),
                AmbientLightSensor.ToString(),
                Autoplay.ToString(),
                EncryptedMedia.ToString(),
                PictureInPicture.ToString(),
                Usb.ToString(),
                Vr.ToString()
            };

            optionValues.AddRange(Other.Select(o =>
            {
                o.Value.FeatureName = o.Key;
                return o.Value.ToString();
            }));

            return string.Join("; ", optionValues.Where(s => s.Length > 0));
        }
    }
}
