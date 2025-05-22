# iOS App Icon Appearance for Unity

<p align="center">
    <img alt="iOS App Icon Appearance for Unity" src="https://raw.githubusercontent.com/artstorm/ios-app-icon-appearance/main/.github/readme/icon.png">
</p>

<p align="center">
    <a href="https://openupm.com/packages/ios-app-icon-appearance/"><img src="https://img.shields.io/npm/v/ios-app-icon-appearance?label=openupm&amp;registry_uri=https://package.openupm.com&labelColor=383f47" alt="openupm" /></a>
    <a href="https://mastodon.gamedev.place/@johansteen"><img src="https://img.shields.io/badge/mastodon-@johansteen-blue.svg?logo=mastodon&logoColor=ffffff&labelColor=383f47" alt="Mastodon: @johansteen" /></a>
    <a href="https://twitter.com/artstorm"><img src="https://img.shields.io/badge/twitter-@artstorm-blue.svg?logo=twitter&logoColor=ffffff&labelColor=383f47" alt="Twitter: @artstorm" /></a>
    <a href="https://discord.gg/WJn7w5WaU9"><img src="https://img.shields.io/badge/chat-discord-blue?logo=discord&logoColor=ffffff&labelColor=383f47" alt="Discord: Bitbebop" /></a>
</p>

## About

This Unity package enables support for Apple's iOS app icon system, allowing you to specify Light (Any Appearance), Dark, and Tinted variants for your app icon. This streamlined approach, utilizing a single 1024x1024px source icon for each variant, was introduced with Xcode 16.

Upon installation, an **`iOS App Icon`** section is added to Unity's `Project Settings`. The icons configured here will override the default iOS icons (specified in `Player Settings`) during the iOS build process.

> [!IMPORTANT]  
> Requires building with Xcode 16 or newer.

## Icon Design Considerations

It's important to design your icon variants according to Apple's Human Interface Guidelines to ensure they look great across the system.

**Key Points from Apple's Guidelines:**

| Variant         | Size        | Background  | Notes                                                                             |
| --------------- | ----------- | ----------- | --------------------------------------------------------------------------------- |
| **Light Mode**  | 1024x1024px | Opaque      | This is your standard "Any Appearance" icon. Design with its own background.      |
| **Dark Mode**   | 1024x1024px | Transparent | Design the foreground elements. The system provides the dark gradient background. |
| **Tinted Mode** | 1024x1024px | Opaque      | Design a grayscale version of icon. The system applies the tint.                  |

For complete details, please refer to Apple's official documentation:

[App Icons - Human Interface Guidelines (iOS & iPadOS)](https://developer.apple.com/design/human-interface-guidelines/app-icons#iOS-iPadOS)

# Usage

Using this package is simple:

1.  **Configure Icons in Project Settings:**

    - After installing the package, navigate to `Edit` → `Project Settings...` in the Unity Editor.
    - Select the `iOS App Icon` tab.
    - Assign your 1024x1024px icons to the desired Any Appearance, Dark, and/or Tinted slots.

![iOS App Icons in Project Settings](https://raw.githubusercontent.com/artstorm/ios-app-icon-appearance/main/.github/readme/unity-project-settings.png)
_Caption: Example of icons assigned in Project Settings._

2.  **Build for iOS:**

    - Open `File` → `Build Settings...`.
    - Select `iOS` as the platform and click `Build` (or `Build And Run`).
    - **Important:** This package modifies the Xcode project to use app icon features introduced with Xcode 16. Ensure your build will be opened and archived with Xcode 16 or newer.

3.  **Verify in Xcode (Xcode 16+):**

    - Open your generated `.xcodeproj` file in Xcode.
    - Navigate to the `Unity-iPhone` folder in the Project Navigator (left sidebar).
    - Open the `Images` asset catalog.
    - In the list of assets within the catalog, select `AppIcon`.
    - You should directly see the editor for `AppIcon` now showing the **"Any Appearance"**, **"Dark"**, and **"Tinted"** wells as the primary input method.
    - Verify that these wells are populated with the respective icons you assigned in Unity.

![Xcode App Icons](https://raw.githubusercontent.com/artstorm/ios-app-icon-appearance/main/.github/readme/xcode-app-icons.png)
_Caption: Example of the AppIcon set in Xcode, showing the variants._

## Installation

Requires Unity 2021.3 LTS or higher.

### OpenUPM

The package is available on the [OpenUPM registry](https://openupm.com). It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```sh
openupm add com.bitbebop.ios-app-icon-appearance
```

### Unity Package Manager and Git URL

Install the package directly in Unity Package Manger using this URL:

```
https://github.com/artstorm/ios-app-icon-appearance.git?path=/Packages/com.bitbebop.ios-app-icon-appearance
```

Open Unity Package Manager → <kbd>+</kbd> → Add package from git URL:

![Add package from git URL](https://raw.githubusercontent.com/artstorm/ios-app-icon-appearance/main/.github/readme/installation-git-1.png)

Paste URL:

![Paste git URL](https://raw.githubusercontent.com/artstorm/ios-app-icon-appearance/main/.github/readme/installation-git-2.png)
