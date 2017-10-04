# Moov2.Orchard.SEO

Useful features to improve SEO on websites using Orchard.

## Getting Started

Download module source code and place within the "Modules" directory of your Orchard installation. 

Alternatively, use the command below to add this module as a sub-module within your Orchard project.

```
git submodule add git@github.com:moov2/Moov2.Orchard.SEO.git modules/Moov2.Orchard.SEO
```

## Features

### Meta tags

Attach the "Meta Info" part to a content item to allow content editors to define content for SEO meta tags (e.g. description).

### Canonical URLs

It's good practice for visitors to always see a consistent structure for page URLs on a website. Whether that's with www, always https or ensuring the URL is all lowercase. This module helps manage URL consistency by providing a checklist of rules that requested URLs should adhere. Requested URLs that break the rules will be redirected (via a `301`) to a URL that points to the same page with a URL that passes the rules. Read more about the [benefits of canonical URLs](https://support.google.com/webmasters/answer/139066) for SEO.

### 301 Redirects

Site content changes can cause pages to be moved/replaced; it's good practice to ensure visitors to old URLs are redirected (commonly a 301 redirect) to a replacement page instead of shown a 404. This feature makes a new content type (`Redirect`) available, which handles performing a 301 redirect from a specified URL to another URL.

### Robots

Customise the contents of `/robots.txt` in order to control behaviour of robots that crawl your site. To learn more about robots.txt head over to the [http://www.robotstxt.org/](http://www.robotstxt.org/). 

When this feature is enabled, you'll be able to control the contents returned when a visitor requests `/robots.txt`. There is a "Robots" field within the SEO settings available in the admin dashboard. By default, when enabled, the `/robots.txt` will instruct robots to not crawl the site.

### Favicon

Customise the media used in the response for requests to `/favicon.ico`.

When this feature is enabled, via the SEO settings available in the admin dashboard, you'll be able to configure the URL to a media asset that'll be returned when a request is made to `/favicon.ico`. The media asset can be selected from the Orchard media library or a custom URL can be entered. If this module is enabled and the Favicon field is empty, a 404 response will be returned.

### Google Analytics

Enter your [Google Analytics](https://www.google.com/analytics) or [Google Tag Manager](https://www.google.com/analytics/tag-manager/), which will be rendered on every page in the site. 

When this feature is enabled, via the SEO settings available in the admin dashboard, you'll be able to enter your Google Analytics tracking code or Google Tag Manager ID. Depending on if these have been configured, everytime a page is served on the Orchard site the relevant JavaScript snippets will be loaded into the `<head>` section of the site.