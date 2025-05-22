# iOS App Icon Appearance for Unity

Use modern iOS app icon appearances (Light, Dark, & Tinted) with Unity, a feature introduced with Xcode 16..

<p align="center">
    <!-- <a href="https://openupm.com/packages/ios-app-icon-appearance/"><img src="https://img.shields.io/npm/v/ios-app-icon-appearance?label=openupm&amp;registry_uri=https://package.openupm.com&labelColor=383f47" alt="openupm" /></a> -->
    <a href="https://mastodon.gamedev.place/@johansteen"><img src="https://img.shields.io/badge/mastodon-@johansteen-blue.svg?logo=mastodon&logoColor=ffffff&labelColor=383f47" alt="Mastodon: @johansteen" /></a>
    <a href="https://twitter.com/artstorm"><img src="https://img.shields.io/badge/twitter-@artstorm-blue.svg?logo=twitter&logoColor=ffffff&labelColor=383f47" alt="Twitter: @artstorm" /></a>
    <a href="https://discord.gg/WJn7w5WaU9"><img src="https://img.shields.io/badge/chat-discord-blue?logo=discord&logoColor=ffffff&labelColor=383f47" alt="Discord: Bitbebop" /></a>
</p>

## About

This Unity package enables support for Apple's modern iOS app icon system, allowing you to specify **Light (Any Appearance)**, **Dark**, and **Tinted** variants for your app icon. This streamlined approach, utilizing a single 1024x1024px source icon for each variant, was **introduced with Xcode 16**.

Upon installation, an **`iOS App Icon`** section is added to Unity's `Project Settings`. The icons configured here will override the default iOS icons (specified in `Player Settings`) during the iOS build process.

**Requires building with Xcode 16 or newer.**

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
