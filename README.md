# L20250207
## 2025.02.07 Study Unity Sound&Record


~취소선~
**Bold**
> 1
>> 2
>>> 3


+ 2025-02-07
  + 유니티 사운드
    + 유니티 오디오 소스

- 2025-02-07
  - 유니티 사운드
    - 유니티 오디오 소스


<Hr></Hr>

안녕하세요. 반갑습니다. 감사합니다.
-----------------------------------


|제목|내용|설명|
|:------------|--------:|:--------:|
|왼쪽 정렬|오른쪽 정렬|중앙 정렬|
|Sample1|Content1|Description1|
|Sample2|Content2|Description2|
|Sample3|Content3|Description3|

<Hr>

### 오디오 소스(Audio Source)
씬에서 오디오 클립(Audio Clip)을 재생하는 도구

>재생을 하기 위해서는 오디오 리스너(Audio Listener)나 오디오 믹서(Audio Mixer)를 통해서 재생 가능함.
>
>믹서의 경우는 따로 만들어야 하고, 오디오 리스너는 메인 카메라에 붙어 있음

* Audio Resource: 재생을 진행할 사운드 클립 등록

* Output
> 기본적으로는 오디오 리스너에 직접 출력(None)
> 만든 오디오 믹서가 존재하면 해당 믹서를 통해 출력

* Mute: 체크 시 음소거 처리

* Bypass Effects: 오디오 소스에 적용되어 있는 필터 효과를 분리

* Bypass Listener Effect: 리스너 효과를 키거나 끄는 기능

* Bypass Reverb Zones: 리버브 존을 키거나 끄는 기능
    * 리버브 존: 오디오 리스너의 위치에 따라 잔향 효과를 설정하는 도구

* Play On Awake: 해당 옵션을 체크했을 경우 씬이 실행되는 시점에 사운드 재생이 처리가 됨
    * 해당 기능 비활성화 시 스크립트를 통해 재생

* Loop: 오디오 클립 반복 유무

* Priority: 오디오 소스의 우선 순위
    * 0 최우선
    * 128 기본
    * 256 최하위

* Volume: 리스너 기준으로 거리 기준 소리에 대한 수치
	컴퓨터 내의 소리를 재생하는 여러 가지 요소 중 하나를 제어

* Pitch: 재생 속도가 빠라지거나 느려질 때의 피치 변화량
    * 1 기본
	* 3 최대
* Stereo Pan: 소리 재생 시 좌우 스피커 간의 소리 분포를 조절
    * -1 왼쪽
	* 0 양쪽 균등
	* 1 오른쪽

* Spatial Blend
    * 0: 사운드가 거리와 상관없이 일정하게 들어감
    * 1: 사운드가 사운드 트는 도구의 거리에 따라 변화
* Reverb Zone Mix: 리버브 존에 대한 출력 신호 양을 조절
	* 0: 영향을 받지 않음
	* 1: 오디오 소스와 리버브 존 사이의 신호 최대치
	* 1.1: 1에서 10dB 증폭

 #### 리버브 존을 따로 설계해야 하는 상황?
> 동굴에서 소리가 울리는 효과 연출
>
> 건물 등에서 다른 부분을 반해서 울리는 소리

- 3D Sound Settings
    - Doopler Level: 거리에 따른 사운드 높낮이 표현
      - 0: 효과 없음
    - Spread: 사운드가 퍼지는 각도(0~360)
          - 0: 한 점에서 사운드가 나옴
          - 360: 모든 방향으로 균일하게 퍼짐
    - Rolloff Mode: 그래프 설정
      - 로그 그래프: 가까우면 사운드가 크고, 멀수록 점점 빠르게 사운드가 작아짐
      - 선형 그래프: 거리에 따라 일정하게 사운드가 변화
      - 커스텀 그래프: 직접 조절

#### AudioMixer
> 오디오 소스에 대한 제어, 균형, 조정을 제공하는 도구
>
> 믹서 만드는 방법
Create > Audio > AudioMixer
최초 생성 시 Master Group 존재

<Hr>

### Mathf 함수

1. Mathf.Deg2Rad
> degree(60분법)을 통해 radian(호도법)을 계산하는 코드
>
> Pi / 180 , (Pi*2) / 360

2. Mathf.Rad2Deg
> radian을 degree로 변환
> 
> 360 / (Pi*2)
> 
> 1radian은 약 57도

3. Mathf.Abs
> 절대값 계산

4. Mathf.Atan
> 아크탄젠트 계산

5. Mathf.Ceil
> 소수점 올림

6. Mathf.Clamp(value, min, max)
> value를 min/max 사이의 값으로 고정하는 기능

7. Mathf.Log10
> 베이스가 10으로 지정되어 있는 수의 로그를 반환

<Hr>

### 유니티에디터에서 GUI 를 보여주는 시스템

1. IMGUI: 디버그에서 사용

2. UGUI: 일반적으로 사용하는 UI 도구

3. UIElements: 에디터 기반으로 진행하는 도구

<Hr>

### 유니티 레코더
> Package Manager > Unity Registry > Recorder 설치하여 사용 가능
>
> window > General > Recorder > Recorder Window

* Exit Play Mode:  체크되어 있으면 녹화 끝나면 플레이도 끝

* Recording Mode
    * Manual: 사용자 직접 녹화 설정 종료 가능

* Playback: 녹화 중 일정 프레임 속도 유지

* Target FPS: 녹화 FPS 지정

* Cap: 설정한 FPS를 넘지 않도록 제한

* Movie
