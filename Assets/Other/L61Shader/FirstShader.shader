Shader "Lesson/First Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color) = (0,0,0,0)
        _Speed ("Speed", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase" }

        Pass
        {
            // CG код
            CGPROGRAM
            
            // обозначить как вертексный шейдер
            #pragma vertex vert 
            // обозначить как пиксельный шейдер
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata // входящие данные
            {
                float4 vertex : POSITION;  // позиция вершины в локальном пространстве модели
                float2 uv : TEXCOORD0; // первая UV координата текстуры
                float3 norm: NORMAL; // запрос нормали вершины
            }; // После структур обязательно ставится знак ";"

            struct v2f // выходящие данные
            {
                float4 vertex : SV_POSITION;  // положение вершины после преобразования в пространстве проекции
                float2 uv : TEXCOORD0; // UV координаты
                float3 worldNormal: TEXCOORD1; // хранение мировых координат нормали
            };

            uniform sampler2D _MainTex; // переменная текстуры из свойств
            uniform fixed4 _Color; // переменная цвета из свойств
            uniform float _Speed; // переменная цвета из свойств
            
            // переменная для хранения данных координат и тайлинга текстуры
            // название текстуры + "_ST"
            float4 _MainTex_ST; 

            //  Вертексный шейдер
            v2f vert (appdata v)
            {
                v2f o; // создаем возвращаемую структуру 
                
                // Преобразует точку из пространства объекта в камеру Пространство клипа в однородных координатах. 
                o.vertex = UnityObjectToClipPos(v.vertex);
                // Масштабирует и смещает координаты текстуры XY - тайлинг, а ZW - смещение
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // переводим нормаль из объектного в мировые координаты
                o.worldNormal = mul(unity_WorldToObject, v.norm);
                
                return o;
            }

            // Пиксельный шейдер
            fixed4 frag (v2f i) : SV_Target // Семантика для цвета COLOR или SV_Target 
            {
                // Дополнительная переменная для изменения цвета
                float4 timeMultiplier = abs(sin(_Time * _Speed));
                // tex2D получает значение цвета из текстуры.
                fixed4 col = tex2D(_MainTex, i.uv); // берем цвет из текстуры по UV координатам
                col = col * _Color * timeMultiplier * _LightColor0; // добавить цвет
                
                float3 l = normalize(_WorldSpaceLightPos0); // нормализуем вектор освещения
                float3 n = normalize(i.worldNormal); // нормализуем вектор нормали 
                float dif = max(0.0, dot(n,l)); // рассчитываем освещенность пикселя 
                col = col * dif;
        
                return col;
            }
            
            ENDCG
        }
    }
    
    SubShader {
        Tags { "RenderType" = "Opaque" }
      
        CGPROGRAM
      
        // идентификация поверхностного шейдера
        #pragma surface surf BlinnPhong
      
        // структура входных данных
        struct Input {
            float2 uv_MainTex;
        };
      
        // используемые данные
        sampler2D _MainTex;
        fixed4 _Color;
        float _Speed;
      
        // сама шейдерная функция
        void surf (Input IN, inout SurfaceOutput o) {
            float4 timeMultiplier = abs(sin(_Time * _Speed));
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color * timeMultiplier;
        }
       
        ENDCG
    }
    
    Fallback "Diffuse"
}
