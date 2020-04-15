#version 430 core
out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;

uniform vec3 eyePos;
uniform samplerCube skybox;

float ratio = 1.0 / 1.52;

void main()
{
	vec3 I = normalize(FragPos - eyePos);
	//vec3 R = reflect(I, normalize(Normal));
	vec3 R = refract(I, normalize(Normal), ratio);
	FragColor = vec4(texture(skybox, R).rgb, 1.0);
}
