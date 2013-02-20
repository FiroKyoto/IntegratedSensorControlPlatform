namespace FieldMap
{
    using System;
    using System.Runtime.InteropServices;

    [ComVisibleAttribute(true)]
    public class External
    {
        /// <summary>
        /// Event fired when the Google earth is ready.
        /// </summary>
        public event EventHandler PluginReady;

        /// <summary>
        /// Event fired when the google earth
        /// plugin detects a mouse-click event.
        /// </summary>
        public event EventHandler KmlMouseClickEvent;

        /// <summary>
        /// Called by the javascript when the google earth plugin successfully loads.
        /// </summary>
        /// <param name="pluginInstance">The plugin instance</param>
        public void JSInitSuccessCallback(object pluginInstance)
        {
            if (PluginReady != null)
                PluginReady(pluginInstance, EventArgs.Empty);
        }

        /// <summary>
        /// Called by the javascript when the Google earth plugin fails to load.
        /// </summary>
        /// <param name="error">The error message</param>
        public void JSInitFailureCallback(string error)
        {
            throw new Exception("Error: " + error);
        }

        /// <summary>
        /// Called by the Javascript when the google earth plugin detects a mouse-click event.
        /// </summary>
        /// <param name="mouseEvent">The KML mouse event</param>
        public void JSMouseClickEventCallback(object mouseEvent)
        {
            if (KmlMouseClickEvent != null)
                KmlMouseClickEvent(mouseEvent, EventArgs.Empty);
        }

    }
}
