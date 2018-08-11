using System.Collections.Generic;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyBuilder
    {
        private readonly FeaturePolicyOptions _options = new FeaturePolicyOptions();
        private readonly List<FeaturePolicyOtherFeatureBuilder> _otherBuilders = new List<FeaturePolicyOtherFeatureBuilder>();

        /// <summary>
        /// Set up rules for Geolocation.
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyGeolocationOptions> AllowGeolocation { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyGeolocationOptions>();
        /// <summary>
        /// Set up rules for Midi
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyMidiOptions> AllowMidi { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyMidiOptions>();
        /// <summary>
        /// Set up rules for Notifications
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyNotificationsOptions> AllowNotifications { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyNotificationsOptions>();
        /// <summary>
        /// Set up rules for Push
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyPushOptions> AllowPush { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyPushOptions>();
        /// <summary>
        /// Set up rules for Sync Xhr
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicySyncXhrOptions> AllowSyncXhr { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicySyncXhrOptions>();
        /// <summary>
        /// Set up rules for Microphone use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyMicrophoneOptions> AllowMicrophone { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyMicrophoneOptions>();
        /// <summary>
        /// Set up rules for Camera use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyCameraOptions> AllowCamera { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyCameraOptions>();
        /// <summary>
        /// Set up rules for Magnetometer
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyMagnetometerOptions> AllowMagnetometer { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyMagnetometerOptions>();
        /// <summary>
        /// Set up rules for Gyroscope
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyGyroscopeOptions> AllowGyroscope { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyGyroscopeOptions>();
        /// <summary>
        /// Set up rules for Speaker use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicySpeakerOptions> AllowSpeaker { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicySpeakerOptions>();
        /// <summary>
        /// Set up rules for Vibrate
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyVibrateOptions> AllowVibrate { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyVibrateOptions>();
        /// <summary>
        /// Set up rules for Fullscreen use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyFullscreenOptions> AllowFullscreen { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyFullscreenOptions>();
        /// <summary>
        /// Set up rules for Payment use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyPaymentOptions> AllowPayment { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyPaymentOptions>();
        /// <summary>
        /// Set up rules for Accelerometer use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyAccelerometerOptions> AllowAccelerometer { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyAccelerometerOptions>();
        /// <summary>
        /// Set up rules for Ambient Light Sensor use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyAmbientLightSensorOptions> AllowAmbientLightSensor { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyAmbientLightSensorOptions>();
        /// <summary>
        /// Set up rules for Autoplay use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyAutoplayOptions> AllowAutoplay { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyAutoplayOptions>();
        /// <summary>
        /// Set up rules for Encrypted Media use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyEncryptedMediaOptions> AllowEncryptedMedia { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyEncryptedMediaOptions>();
        /// <summary>
        /// Set up rules for Picture in Picture use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyPictureInPictureOptions> AllowPictureInPicture { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyPictureInPictureOptions>();
        /// <summary>
        /// Set up rules for USB use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyUsbOptions> AllowUsb { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyUsbOptions>();
        /// <summary>
        /// Set up rules for VR use
        /// </summary>
        public FeaturePolicyFeatureBuilder<FeaturePolicyVrOptions> AllowVr { get; } = new FeaturePolicyFeatureBuilder<FeaturePolicyVrOptions>();

        /// <summary>
        /// Set up rules for any feature
        /// </summary>
        /// <param name="featureName">Name of the feature you want rules for.
        /// The official list is at https://github.com/WICG/feature-policy/blob/master/features.md</param>
        public FeaturePolicyOtherFeatureBuilder AllowOtherFeature(string featureName)
        {
            var options = new FeaturePolicyOtherFeatureOptions(featureName);
            var builder = new FeaturePolicyOtherFeatureBuilder(options);
            _otherBuilders.Add(builder);
            return builder;
        }

        public FeaturePolicyOptions BuildFeaturePolicyOptions()
        {
            _options.Geolocation = AllowGeolocation.BuildOptions();
            _options.Midi = AllowMidi.BuildOptions();
            _options.Notifications = AllowNotifications.BuildOptions();
            _options.Push = AllowPush.BuildOptions();
            _options.SyncXhr = AllowSyncXhr.BuildOptions();
            _options.Microphone = AllowMicrophone.BuildOptions();
            _options.Camera = AllowCamera.BuildOptions();
            _options.Magnetometer = AllowMagnetometer.BuildOptions();
            _options.Gyroscope = AllowGyroscope.BuildOptions();
            _options.Speaker = AllowSpeaker.BuildOptions();
            _options.Vibrate = AllowVibrate.BuildOptions();
            _options.Fullscreen = AllowFullscreen.BuildOptions();
            _options.Payment = AllowPayment.BuildOptions();
            _options.Accelerometer = AllowAccelerometer.BuildOptions();
            _options.AmbientLightSensor = AllowAmbientLightSensor.BuildOptions();
            _options.Autoplay = AllowAutoplay.BuildOptions();
            _options.EncryptedMedia = AllowEncryptedMedia.BuildOptions();
            _options.PictureInPicture = AllowPictureInPicture.BuildOptions();
            _options.Usb = AllowUsb.BuildOptions();
            _options.Vr = AllowVr.BuildOptions();
            _options.Other = _otherBuilders.Select(b => b.BuildOptions()).ToDictionary(o => o.FeatureName);

            return _options;
        }
    }
}
