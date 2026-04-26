<?php

use BookStack\Facades\Theme;
use BookStack\Theming\ThemeEvents;
use BookStack\Theming\ThemeViews;
use League\CommonMark\Environment\Environment;
use League\CommonMark\Extension\Footnote\FootnoteExtension;
use League\CommonMark\Extension\Autolink\AutolinkExtension;
use League\CommonMark\Extension\DisallowedRawHtml\DisallowedRawHtmlExtension;

Theme::listen(ThemeEvents::COMMONMARK_ENVIRONMENT_CONFIGURE, function(Environment $environment)
{
    $environment->addExtension(new FootnoteExtension());
    $environment->addExtension(new AutolinkExtension());
    $environment->addExtension(new DisallowedRawHtmlExtension());
    $environment->mergeConfig([
        'renderer' => [
            'soft_break'      => "\n",
        ],
    ]);
});

// Register a module view
Theme::listen(ThemeEvents::THEME_REGISTER_VIEWS, function (ThemeViews $themeViews) {
    $themeViews->renderAfter('layouts.parts.custom-head', 'markdown-extensions-import-scripts', 10);
});

