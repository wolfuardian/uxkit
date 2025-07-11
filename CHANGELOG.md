# Changelog

All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/).

## [0.1.7-alpha] - 2025-07-12

### Added

- Added event components with multiple dispatching mechanisms
- Added Event Dispatcher Manager
- Added occlusion detection functionality (CameraLib & RectTrackScript)
- Added camera culling mask control methods
- Added default layer assignment for camera culling masks

### Changed

- Renamed event-related fields and methods for better clarity
- Simplified and removed redundant event properties and features
- Renamed occlusion-related fields and methods for consistency
- Moved static utility functions to CameraLib
- Exposed internal fields (e.g., `camera`, `graphic`) for editor customization
- Used Canvas Group to simulate occlusion effects

### Fixed

- Fixed unexposed `camera` and `graphic` fields preventing editor assignment

### Removed

- Removed unnecessary event types and ambiguous fields

## [0.1.6-alpha.2] - 2025-07-09

### Changed

- Renaming _isSelected field to _isOn

## [0.1.6-alpha.1] - 2025-07-09

### Changed

- Make _isSelected field serializable in LsSelect

## [0.1.6-alpha] - 2025-07-09

### Added

- Add fundamental camera methods

## [0.1.5-alpha] - 2025-07-08

### Added

- Add LsRectTrackMousePosition.cs
- Add LsRectTrackScreenPoint.cs

## [0.1.4-alpha.3] - 2025-07-08

### Changed

- Unify naming convention from m_ to _ across LsMaterialOverride

## [0.1.4-alpha.2] - 2025-07-08

### Fixed

- Rollback to previous class names

## [0.1.4-alpha.1-experimental] - 2025-07-08

## [0.1.4-alpha.1] - 2025-07-08

### Fixed

- Fix namespace

## [0.1.4-alpha] - 2025-07-08

### Added

- Add LsMaterialOverriede.cs

## [0.1.3-alpha.1] - 2025-07-07

### Changed

- Update Sample scnee's demo. More clarity.

## [0.1.3-alpha] - 2025-07-07

### Added

- Add LsSelect.cs

### Changed

- Change LsSwitchGameObject.cs method logic (can be effected by this.enable)

## [0.1.2-alpha] - 2025-07-07

### Added

- Add Sample Scene (To Test and Demo)

## [0.1.1-alpha.1] - 2025-07-07

### Fixed

- Add missing meta files

## [0.1.1-alpha] - 2025-07-06

### Added

- Add LsSwitchGameObject.cs

## [0.1.0-alpha] - 2025-07-06

### Added

- Project initialized.
- Core package structure created.
