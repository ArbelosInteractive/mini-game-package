# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Released]

## [1.0.0] - 2023-02-20
### Added
- Initial setup of package

## [1.0.1] - 2023-02-25
### Changed
- Made addressables downloader and manager into MonoBehaviour 

## [1.0.2] - 2023-02-25
### Added
- Added AsyncOperationHandleExtensions

## [1.0.3] - 2023-02-25
### Changed
- Made various methods and variables protected in downloader and manager scripts

## [1.0.4] - 2023-02-25
### Removed
- Removed abstract keyword from addressables manager

### Added
- Added OnDestroy method to addressables manager

## [1.0.5] - 2023-02-25
### Changed
- Changed header text to better reflect fields
- Made fields public

### Added
- Added a MiniGameDataMode which can be set to indicate where to get the data from

## [1.0.6] - 2023-02-25
### Added
- Added awake method to addressables manager

## [1.0.7] - 2023-02-26
### Changed
- Changed method signature of MiniGameCompleted

## [1.0.8] - 2023-02-26
### Changed
- Updated OnMiniGameCompleted on MiniGameManager

## [1.0.9] - 2023-02-26
### Changed
- Changed GUIDs on various meta files

## [1.0.10] - 2023-02-26
### Changed
- Changed Addressables Manager to networked

## [1.0.11] - 2023-02-27
### Added
- Added QuestID and ObjectiveID to mini game data holder

## [1.0.12] - 2023-02-28
### Added
- Added IAddressablesManager
- Removed AddressableManagerNetworked
- Updated ReadMe

## [1.0.13] - 2023-03-01
### Added
- Added a trivia game to samples
- Update gitignore

## [1.0.14] - 2023-03-29
### Added
- Added a difficulty setting for mini game
- Update variable names in mini game data holder

## [1.0.15] - 2023-04-03
### Removed
- Removed difficulty setting since that will come from gooru

### Changed
- Update variable names in mini game data holder

## [1.0.16] - 2023-04-03
### Added
- Added a custom inspector that only displays fields related to the data mode selected

## [1.0.17] - 2023-05-01
### Added
- Added two new methods to IMiniGame interface to save/load minigame data