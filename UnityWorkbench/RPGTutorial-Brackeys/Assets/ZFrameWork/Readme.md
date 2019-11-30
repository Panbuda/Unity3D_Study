# Readme

## 使用须知

1. 使用ZMonobehaviour类来代替Monobehaviour类时，禁止使用OnDestroy()方法，而是使用OnBeforeDestroy()方法，否则会产生不可预估的内存错误。
2. 要正常使用OutputFramework功能，需正确配置Bat文件夹环境变量，/Framework/Editor/Exporter.cs文件内的参数，以及Git。

