#version 430 core

struct Material {
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
	float shininess;
};

struct Light {
	vec3 position;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

uniform Material material;
uniform Light light;

in vec3 Normal;
in vec3 FragPos;

out vec4 FragColor;

uniform vec3 eyePos;

void main() 
{
	// ambient
    vec3 ambient = material.ambient * light.ambient;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = (diff * material.diffuse) * light.diffuse;

	// specular
	vec3 viewDir = normalize(eyePos - FragPos);
	vec3 reflected = reflect(-lightDir, norm);
	float spec = pow(max(dot(reflected, viewDir), 0.0), material.shininess);
	vec3 specular = light.specular * (spec * material.specular);

            
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}