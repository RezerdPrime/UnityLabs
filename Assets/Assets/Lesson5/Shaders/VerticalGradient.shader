Shader "Unlit/VerticalGradient"
{
    Properties
    {
        _ColorA("Color A", Color) = (1,0,0,1)
        _ColorB("Color B", Color) = (0,0,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" } // Очередь для отрисовки 
        LOD 100 // Уровень деталей - в зависимости от расстояния до объекта можно прописать разное поведение

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;
            // Информация о модели
            struct appdata //meshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };


            // Информация о фрагментах полученная из векторов
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : TEXCOORD1;
                float4 worldPos : SV_POSITION;
            };


            // Обработка на уровне векторов скорее всего меньше всего влияет на производительность
            v2f vert (appdata v)
            {
                v2f o;
                o.worldPos = UnityObjectToClipPos(v.vertex);
                o.vertex = v.vertex; 
                o.uv = v.uv;
                return o;
            }

            // Обработка на уровне фрагментов
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                return lerp(_ColorA, _ColorB, i.vertex.y +0.5);
            }
            ENDCG
        }
    }
}
