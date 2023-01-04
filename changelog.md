# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/3.0.0) - 2023-01-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/8?closed=1)  
    null

### Changed

- Update project ([#23](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/23))  
    - Update dependencies: `com.ugf.jsonnet` to `1.5.0` version.
    - Update package _Unity_ version to `2022.2`.

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/3.0.0-preview.1) - 2022-12-19  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/7?closed=1)  
    

### Fixed

- Fix serializer convert names missing labels ([#21](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/21))  
    - Update dependencies: `com.ugf.serialize` to `5.3.1` and `com.ugf.editortools` to `2.15.0` versions.
    - Fix `SerializerJsonNetConvertNamesAsset` class missing display in inspector of labels for `Serialize Names` and `Deserialize Names` collections.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/3.0.0-preview) - 2022-12-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/6?closed=1)  
    

### Added

- Add serialize type collection support  ([#19](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/19))  
    - Update dependencies: `com.ugf.serialize` to `5.3.0` version.
    - Update package _Unity_ version to `2021.3`.
    - Change `SerializerJsonNetConvertTypesAsset` class to work with `SerializeTypeCollectionAsset` and remove legacy type data.
    - Remove `SerializerJsonNetTypeAttribute`, `SerializerJsonNetConvertTypeCollectionAsset`, `SerializerJsonNetConvertTypeProviderAsset` and related classes, use `SerializeTypeAttribute` attribute and `SerializeTypeCollectionAsset` collection instead.

## [2.3.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/2.3.0) - 2022-03-20  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/5?closed=1)  
    

### Added

- Add optimized way to search for type ([#16](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/16))  
    - Change `SerializerJsonNetConvertTypeCollectionAsset` inspector dropdown to search for supported serializable types only.
- Add button to generate id in type collection ([#15](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/15))  
    - Add `SerializerJsonNetConvertTypeCollectionAsset` inspector with button to refresh id of selected type.
    - Change `SerializerJsonNetConvertTypeCollectionAsset` inspector to automatically generate id for type with empty id specified in attribute
    - Change `SerializerJsonNetTypeAttribute` constructor to allow empty id.

## [2.2.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/2.2.0) - 2022-02-08  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/4?closed=1)  
    

### Added

- Add serializer type attribute for collection ([#13](https://github.com/unity-game-framework/ugf-serialize-jsonnet/issues/13))  
    - Add `SerializerJsonNetTypeAttribute` attribute class to define type id information for classes and structures.
    - Change `SerializerJsonNetConvertTypeCollectionAssetEditor` class to be public and add `OnCollectTypes()` overridable method to implement custom collect type logic.

## [2.1.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/2.1.0) - 2021-12-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/3?closed=1)  
    

### Added

- Add generate type ids for type name converter ([#12](https://github.com/unity-game-framework/ugf-serialize-jsonnet/pull/12))  
    - Update package _Unity_ version to `2021.2`.
    - Update dependencies: `com.ugf.serialize` to `5.0.0` and `com.ugf.jsonnet` to `1.4.0` version.
    - Add `SerializerJsonNetConvertTypesAsset.AllowAllTypes` property to determine whether to allow types which have not been added to the list.
    - Add `SerializerJsonNetConvertTypesAsset.TypeProviders` property as collection of `SerializerJsonNetConvertTypeProviderAsset` assets which will be added to type provider.
    - Add `SerializerJsonNetConvertTypeProviderAsset` abstract class to implement custom type provider.
    - Add `SerializerJsonNetConvertTypeCollectionAsset` class as implementation of `SerializerJsonNetConvertTypeProviderAsset` class with collection of types by id.

## [2.0.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/2.0.0) - 2021-07-24  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/2?closed=1)  
    

### Added

- Add JsonSerializerSettings properties in serializer asset ([#10](https://github.com/unity-game-framework/ugf-serialize-jsonnet/pull/10))  
    - Change package _Unity_ version to `2020.3`.
    - Add `SerializerJsonNetSettings` class with serializable _JsonNet Serializer Settings_ properties.
    - Add `SerializerJsonNetAsset.OnCreateSettings()` method to override _JsonNet Serializer Settings_ creation.

### Changed

- Update for latest serialize package ([#9](https://github.com/unity-game-framework/ugf-serialize-jsonnet/pull/9))  
    - Update dependencies: `com.ugf.serialize` to `5.0.0-preview` and `com.ugf.jsonnet` to `1.3.0`.

## [1.0.1](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/1.0.1) - 2021-02-27  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-serialize-jsonnet/milestone/1?closed=1)  
    

### Changed

- Update package registry ([#5](https://github.com/unity-game-framework/ugf-serialize-jsonnet/pull/5))  
    - Update package publish registry.

### Fixed

- Fix missing readable formatting in custom serializer ([#6](https://github.com/unity-game-framework/ugf-serialize-jsonnet/pull/6))

## [1.0.0](https://github.com/unity-game-framework/ugf-serialize-jsonnet/releases/tag/1.0.0) - 2021-01-15  

### Release Notes

- No release notes.


