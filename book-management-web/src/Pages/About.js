import React from 'react'

import ReactMarkdown from 'react-markdown'
import remarkGfm from 'remark-gfm'

const markdown = `
### About Markdown
A paragraph with *emphasis* and **strong importance**.

> A block quote with ~strikethrough~ and a URL: https://reactjs.org.

* Lists
* [ ] todo
* [x] done

A table:

| a | b |
| - | - |
| sample01 | sample 02 |
`

const About = () => {
  return (
    <div>
      <ReactMarkdown children={markdown} remarkPlugins={[remarkGfm]} />
    </div>
  )
}

export default About
