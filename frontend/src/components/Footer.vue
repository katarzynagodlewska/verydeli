<template>
  <footer class="info">
    <h2 class="info__title">verydeli</h2>
    <div class="info-row">
      <div class="download">
        <img class="download__img" src="../assets/img/ios-en.svg" />
        <img class="download__img" src="../assets/img/android-en.png" />
      </div>
      <div class="join">
        <h4 class="join__title">Join to verydeli</h4>
        <ul class="join__list">
          <li class="join__item">
            <a class="join__link">User account</a>
          </li>
          <li class="join__item">
            <a class="join__link">Restaurant account</a>
          </li>
          <li class="join__item">
            <a class="join__link">Courier account</a>
          </li>
        </ul>
      </div>
    </div>
    <div class="info-bottom">
      <p class="author-info">Created by Katarzyna Godlewska</p>
      <ul class="social">
        <li class="social__item">
          <a class="social__link" href="https://www.facebook.com/katarzyna.godlewska.71">
            <img class="social__icon" src="../assets/img/icon-fb.svg" alt="facebook" />
          </a>
        </li>
        <li class="social__item">
          <a class="social__link" href="https://github.com/katarzynagodlewska">
            <img class="social__icon" src="../assets/img/icon-github.svg" alt="github" />
          </a>
        </li>
        <li class="social__item">
          <a class="social__link" href="https://www.instagram.com/world_around_kate/">
            <img class="social__icon" src="../assets/img/icon-instagram.svg" alt="instagram" />
          </a>
        </li>
      </ul>
    </div>
  </footer>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "Footer",
})
export default class Footer extends Vue {}
</script>

<style lang="scss">
@import "../styles/modules/footer.scss";
</style>