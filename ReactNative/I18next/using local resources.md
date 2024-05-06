# Notes

#1 install 

```
npm install i18next react-i18next
```

#2 initialization

```TypeScript

import i18n from 'i18next';
import {initReactI18next} from 'react-i18next';
import en from '@/locales/en.json';
import zh from '@/locales/zh.json';
import '@formatjs/intl-pluralrules/locale-data/zh';
import '@formatjs/intl-pluralrules/locale-data/en';

i18n.use(initReactI18next).init({
  compatibilityJSON: 'v3',
  resources: {
    en: {
      translation: en,
    },
    zh: {
      translation: zh,
    },
  },
  lng: 'en',
  fallbackLng: 'en',
  interpolation: {
    escapeValue: false,
  },
  pluralSeparator: '',
});
export default i18n;

```

**In Android, "compatibilityJSON: 'v3'" is a great solution for the error: 'It suggests that your environment doesn't support the Intl API, which is required for i18next's pluralization rules based on the ECMAScript Internationalization API'**

#3 using in components

```TypeScript

import {useTranslation} from 'react-i18next';

const {t} = useTranslation();

console.log(t('targetPath'));

```

#4 switching language

```TypeScript
import i18n from '@/utils/i18n';

i18n.changeLanguage(targetLang);

```