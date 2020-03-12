using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Base
{
	public class LayerStack : IEnumerable<Layer>
	{
		private List<Layer> layers;
		private int layerInsertIndex;

		public LayerStack() => layers = new List<Layer>();

		~LayerStack()
		{
			foreach (Layer layer in layers)
			{
				layer.OnDetach();
			}
		}

		public void PushLayer(Layer layer)
		{
			Debug.Assert(!layers.Contains(layer), "LayerStack already contains layer " + layer.GetDebugName());

			layers.Insert(layerInsertIndex++, layer);
			layer.OnAttach();
		}

		public void PushOverlay(Layer layer)
		{
			Debug.Assert(!layers.Contains(layer), "LayerStack already contains overlay " + layer.GetDebugName());

			layers.Add(layer);
			layer.OnAttach();
		}

		public void PopLayer(Layer layer)
		{
			int index = layers.IndexOf(layer);
			if (index >= 0 && index < layerInsertIndex)
			{
				layer.OnDetach();
				layers.Remove(layer);
				layerInsertIndex--;
			}
		}

		public void PopOverlay(Layer layer)
		{
			int index = layers.IndexOf(layer);
			if (index >= layerInsertIndex && index < layers.Count)
			{
				layer.OnDetach();
				layers.Remove(layer);
			}
		}

		public IEnumerable<Layer> TrickleDown()
		{
			for (int i = layers.Count - 1; i >= 0; i--) yield return layers[i];
		}

		public IEnumerable<Layer> BobUp()
		{
			for (int i = 0; i < layers.Count; i++) yield return layers[i];
		}

		public IEnumerator<Layer> GetEnumerator()
		{
			for (int i = layers.Count - 1; i >= 0; i--) yield return layers[i];
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}