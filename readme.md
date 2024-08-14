# BookStack Customize - Markdown Editor extensions

This uses a logical theme to add customization to the Markdown editor.  
In this example, we specifically add the following  

- Customization to CommonMark parser
    - Add FootnoteExtension
    - Add AutolinkExtension
    - Add DisallowedRawHtmlExtension
- Customization to markdown-it front-end previewer
    - Footnote formatting
    - Autolink enable

Customization to the markdown-it front end requires the following code to be added to the header customization from the BookStack settings screen.  

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/markdown-it-footnote/4.0.0/markdown-it-footnote.min.js" integrity="sha512-giw4jyv75ngVba/TWbP9ouANTIA67sJoNWUvOW8ogr1NqByolnc+jbIwj+yAJ0eF/5SLfwv8IZoIVu8bN5XWRw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script src="/custom/md-it-footnote.js"></script>
```