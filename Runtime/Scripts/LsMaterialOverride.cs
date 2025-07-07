using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace NADI.Eos
{
    public class LsMaterialOverride : MonoBehaviour
    {
        [SerializeField] private Material m_MaterialTarget;

        [SerializeField] private Settings m_Settings = new Settings();

        private readonly List<MeshRendererData> _meshRendererData = new List<MeshRendererData>();
        private readonly List<LineRendererData> _lineRendererData = new List<LineRendererData>();
        private readonly List<ImageRendererData> _imageRendererData = new List<ImageRendererData>();

        private bool hasAnyMeshRenderer => _meshRendererData != null && _meshRendererData.Count > 0;
        private bool hasAnyLineRenderer => _lineRendererData != null && _lineRendererData.Count > 0;
        private bool hasAnyImageRenderer => _imageRendererData != null && _imageRendererData.Count > 0;

        public Settings settings => m_Settings;

        public void OverrideMaterials(bool isOverride)
        {
            _meshRendererData.ForEach(data => data.m_MeshRenderer.sharedMaterials = isOverride ? data.m_MaterialsInstance : data.m_MaterialsDefault);
            _lineRendererData.ForEach(data => data.m_LineRenderer.sharedMaterials = isOverride ? data.m_MaterialsInstance : data.m_MaterialsDefault);
            _imageRendererData.ForEach(data => data.m_ImageRenderer.material = isOverride ? data.m_MaterialInstance : data.m_MaterialDefault);
        }

        public void OverrideMaterials() => OverrideMaterials(isOverride: true);
        public void RestoreDefaultMaterial() => OverrideMaterials(isOverride: false);

        private void Awake()
        {
            _meshRendererData.Clear();
            _lineRendererData.Clear();
            _imageRendererData.Clear();

            var mrs = settings.overrideCustomRenderers ? settings.meshRenderers : GetComponentsInChildren<MeshRenderer>().ToList();
            mrs.ForEach(meshRenderer =>
            {
                _meshRendererData.Add(new MeshRendererData
                {
                    m_MeshRenderer = meshRenderer,
                    m_MaterialsDefault = meshRenderer.sharedMaterials,
                    m_MaterialsInstance = meshRenderer.sharedMaterials
                });
            });
            var mls = settings.overrideCustomRenderers ? settings.lineRenderers : GetComponentsInChildren<LineRenderer>().ToList();
            mls.ForEach(lineRenderer =>
            {
                _lineRendererData.Add(new LineRendererData
                {
                    m_LineRenderer = lineRenderer,
                    m_MaterialsDefault = lineRenderer.sharedMaterials,
                    m_MaterialsInstance = lineRenderer.sharedMaterials
                });
            });
            var imageRenderers = settings.overrideCustomRenderers ? settings.imageRenderers : GetComponentsInChildren<UnityEngine.UI.Image>().ToList();
            imageRenderers.ForEach(imageRenderer =>
            {
                _imageRendererData.Add(new ImageRendererData
                {
                    m_ImageRenderer = imageRenderer,
                    m_MaterialDefault = imageRenderer.material,
                    m_MaterialInstance = imageRenderer.material
                });
            });

            _meshRendererData.ForEach(data => System.Array.Fill(data.m_MaterialsInstance, m_MaterialTarget));
            _lineRendererData.ForEach(data => System.Array.Fill(data.m_MaterialsInstance, m_MaterialTarget));
            _imageRendererData.ForEach(data => data.m_MaterialInstance = m_MaterialTarget);

            if (!hasAnyMeshRenderer && !hasAnyLineRenderer && !hasAnyImageRenderer)
            {
                Debug.LogWarning("AfMaterialOverride: No MeshRenderer ,LineRenderer or Image found in children. Please add at least one to use material override functionality.", this);
            }
        }

        private void Start()
        {
            if (settings.overrideOnStart)
            {
                OverrideMaterials();
            }
        }

        [System.Serializable]
        public class Settings
        {
            public bool overrideOnStart = false;
            public bool overrideCustomRenderers = false;
            public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
            public List<LineRenderer> lineRenderers = new List<LineRenderer>();
            public List<UnityEngine.UI.Image> imageRenderers = new List<UnityEngine.UI.Image>();
        }

        [System.Serializable]
        public class MeshRendererData
        {
            public MeshRenderer m_MeshRenderer;
            public Material[] m_MaterialsDefault;
            public Material[] m_MaterialsInstance;
        }

        [System.Serializable]
        public class LineRendererData
        {
            public LineRenderer m_LineRenderer;
            public Material[] m_MaterialsDefault;
            public Material[] m_MaterialsInstance;
        }

        [System.Serializable]
        public class ImageRendererData
        {
            public UnityEngine.UI.Image m_ImageRenderer;
            public Material m_MaterialDefault;
            public Material m_MaterialInstance;
        }
    }
}
