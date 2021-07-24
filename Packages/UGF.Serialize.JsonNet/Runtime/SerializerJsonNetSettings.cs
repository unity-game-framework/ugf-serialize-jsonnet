using System;
using Newtonsoft.Json;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    [Serializable]
    public class SerializerJsonNetSettings
    {
        [SerializeField] private ReferenceLoopHandling m_referenceLoopHandling = ReferenceLoopHandling.Ignore;
        [SerializeField] private MissingMemberHandling m_missingMemberHandling = MissingMemberHandling.Ignore;
        [SerializeField] private ObjectCreationHandling m_objectCreationHandling = ObjectCreationHandling.Auto;
        [SerializeField] private NullValueHandling m_nullValueHandling = NullValueHandling.Ignore;
        [SerializeField] private DefaultValueHandling m_defaultValueHandling = DefaultValueHandling.Include;
        [SerializeField] private PreserveReferencesHandling m_preserveReferencesHandling = PreserveReferencesHandling.None;
        [SerializeField] private TypeNameHandling m_typeNameHandling = TypeNameHandling.Auto;
        [SerializeField] private MetadataPropertyHandling m_metadataPropertyHandling = MetadataPropertyHandling.Default;
        [SerializeField] private TypeNameAssemblyFormatHandling m_typeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
        [SerializeField] private ConstructorHandling m_constructorHandling = ConstructorHandling.Default;
        [SerializeField] private Formatting m_formatting = Formatting.None;
        [SerializeField] private DateFormatHandling m_dateFormatHandling = DateFormatHandling.IsoDateFormat;
        [SerializeField] private DateTimeZoneHandling m_dateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
        [SerializeField] private DateParseHandling m_dateParseHandling = DateParseHandling.DateTime;
        [SerializeField] private FloatFormatHandling m_floatFormatHandling = FloatFormatHandling.String;
        [SerializeField] private FloatParseHandling m_floatParseHandling = FloatParseHandling.Double;
        [SerializeField] private StringEscapeHandling m_stringEscapeHandling = StringEscapeHandling.Default;
        [SerializeField] private string m_dateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
        [SerializeField] private int m_maxDepth;
        [SerializeField] private bool m_checkAdditionalContent;

        public ReferenceLoopHandling ReferenceLoopHandling { get { return m_referenceLoopHandling; } set { m_referenceLoopHandling = value; } }
        public MissingMemberHandling MissingMemberHandling { get { return m_missingMemberHandling; } set { m_missingMemberHandling = value; } }
        public ObjectCreationHandling ObjectCreationHandling { get { return m_objectCreationHandling; } set { m_objectCreationHandling = value; } }
        public NullValueHandling NullValueHandling { get { return m_nullValueHandling; } set { m_nullValueHandling = value; } }
        public DefaultValueHandling DefaultValueHandling { get { return m_defaultValueHandling; } set { m_defaultValueHandling = value; } }
        public PreserveReferencesHandling PreserveReferencesHandling { get { return m_preserveReferencesHandling; } set { m_preserveReferencesHandling = value; } }
        public TypeNameHandling TypeNameHandling { get { return m_typeNameHandling; } set { m_typeNameHandling = value; } }
        public MetadataPropertyHandling MetadataPropertyHandling { get { return m_metadataPropertyHandling; } set { m_metadataPropertyHandling = value; } }
        public TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling { get { return m_typeNameAssemblyFormatHandling; } set { m_typeNameAssemblyFormatHandling = value; } }
        public ConstructorHandling ConstructorHandling { get { return m_constructorHandling; } set { m_constructorHandling = value; } }
        public Formatting Formatting { get { return m_formatting; } set { m_formatting = value; } }
        public DateFormatHandling DateFormatHandling { get { return m_dateFormatHandling; } set { m_dateFormatHandling = value; } }
        public DateTimeZoneHandling DateTimeZoneHandling { get { return m_dateTimeZoneHandling; } set { m_dateTimeZoneHandling = value; } }
        public DateParseHandling DateParseHandling { get { return m_dateParseHandling; } set { m_dateParseHandling = value; } }
        public FloatFormatHandling FloatFormatHandling { get { return m_floatFormatHandling; } set { m_floatFormatHandling = value; } }
        public FloatParseHandling FloatParseHandling { get { return m_floatParseHandling; } set { m_floatParseHandling = value; } }
        public StringEscapeHandling StringEscapeHandling { get { return m_stringEscapeHandling; } set { m_stringEscapeHandling = value; } }
        public string DateFormatString { get { return m_dateFormatString; } set { m_dateFormatString = value; } }
        public int MaxDepth { get { return m_maxDepth; } set { m_maxDepth = value; } }
        public bool CheckAdditionalContent { get { return m_checkAdditionalContent; } set { m_checkAdditionalContent = value; } }
    }
}
