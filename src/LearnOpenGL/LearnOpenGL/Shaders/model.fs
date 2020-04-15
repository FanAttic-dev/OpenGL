#version 430 core

out vec4 FragColor;

struct Material {
	sampler2D texture_diffuse1;
	sampler2D texture_specular1;
	float shininess;
};

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform Material material;
uniform samplerCube skybox;
uniform vec3 eyePos;

void main() 
{
	vec3 I = normalize(FragPos - eyePos);
	vec3 R = reflect(I, normalize(Normal));
	vec4 reflectionColor = vec4(texture(skybox, R).rgb, 1.0);

	vec4 materialColor = texture(material.texture_diffuse1, TexCoords);

	FragColor = (1 - materialColor.a) * materialColor + materialColor.a * reflectionColor;
}