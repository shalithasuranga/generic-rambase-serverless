import os 


def main():
  templateYml = """
  provider:
    name: faas
    gateway: http://172.20.5.81:31112

  functions:
    {func_name}:
      lang: Dockerfile
      handler: .
      image: sharancher/{func_name}:latest

  """

  functionName = input("faas name : ")



  ymlFile = open(functionName + ".yml", "w")

  templateYml = templateYml.replace("{func_name}", functionName)

  ymlFile.write(templateYml)

  ymlFile.close()

  os.system("sudo faas-cli build -f " + functionName + ".yml")
  os.system("sudo faas-cli push -f " + functionName + ".yml")
  os.system("sudo faas-cli deploy -f " + functionName + ".yml")



main()